using ElgamalSandbox.Core.Abstractions;
using ElgamalSandbox.Core.Entities;
using ElgamalSandbox.Core.Enums;
using ElgamalSandbox.Core.Exceptions;
using IronPython.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ElgamalSandbox.Core.Services
{
    public class TaskRunner
    {
        private const int AttemptsMaxCount = 5;

        private readonly IDbContext _dbContext;
        private readonly ILogger<TaskRunner> _logger;
        private readonly ScriptEngine _engine;

        public TaskRunner(
            IDbContext dbContext,
            ILogger<TaskRunner> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _engine = Python.CreateEngine();

            var paths = _engine.GetSearchPaths()
                .Append(Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "PythonModules"))
                .ToList();

            _engine.SetSearchPaths(paths);
        }

        public async Task RunAsync(TaskAttempt taskAttempt)
        {
            var code = PrepareScript(taskAttempt);

            try
            {
                switch (taskAttempt.Type)
                {
                    case AttemptTypes.Typical:
                        var outputVars = RunCode(taskAttempt, taskAttempt.Parameters, code);
                        taskAttempt.Result = string.Join(
                            Environment.NewLine,
                            outputVars.Select(x => $"{x.Name} = {x.Value}"));
                        break;
                    case AttemptTypes.Test:
                        RunTests(taskAttempt, code);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                taskAttempt.IsSucceeded = true;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Ошибка выполнения скрипта");
                taskAttempt.Result = e.ToString();
            }

            if (taskAttempt.IsNew)
                _dbContext.TaskAttempts.Add(taskAttempt);
            else
                _dbContext.TaskAttempts.Update(taskAttempt);

            await _dbContext.SaveChangesAsync();
        }

        public static string PrepareScriptForDisplay(string code)
        {
            return new Regex(
                @"^ +global[\w\d ,]+$\n",
                RegexOptions.Compiled | RegexOptions.Multiline)
                .Replace(code, "");
        }

        private static string PrepareScript(TaskAttempt taskAttempt)
        {
            return PrepareScriptForDisplay(
                taskAttempt.TaskDescription.InputVars
                    .Aggregate(
                        taskAttempt.Code,
                        (acc, cur) =>
                            acc.Replace($"{cur} = None\n", "")));
        }

        private void RunTests(TaskAttempt taskAttempt, string code)
        {
            var lastResult = TestResult.Success;
            foreach (var test in taskAttempt.TaskDescription.Tests)
            {
                if (lastResult == TestResult.Success)
                {
                    var result = RunCode(taskAttempt, test.InputVars, code);

                    lastResult = result.All(x =>
                        test.OutputVars.TryGetValue(x.Name, out var value)
                        && value.Equals(x.Value.ToString()))
                        ? TestResult.Success
                        : TestResult.Failure;
                }

                taskAttempt.Tests.Add(new TaskTestAttemptRelation
                {
                    Attempt = taskAttempt,
                    Test = test,
                    Result = lastResult,
                });

                if (lastResult == TestResult.Failure)
                    lastResult = TestResult.Skipped;
            }

            taskAttempt.Result = "";
        }

        public async Task RunPerformanceTestAsync(
            PerformanceTestAttempt test,
            Action<long, TimeSpan?, long?, int> callback,
            CancellationToken cancellationToken = default)
        {
            var prepareScript = test.PerformanceTest.PrepareScript;

            var attempt = test.PerformanceTest.TaskDescription.Attempts
                .Where(x => x.IsSucceeded)
                .MaxBy(x => x.CreatedAt)
                ?? throw new ApplicationExceptionBase("Удачный запуск скрипта не найден");
            var code = PrepareScript(attempt);

            var runs = test.Runs.ToList();

            for (var index = 0; index < runs.Count; index++)
            {
                var value = runs[index].Key;
                if (cancellationToken.IsCancellationRequested)
                {
                    test.Runs[value] = default;
                    callback(
                        value,
                        test.Runs[value],
                        runs.Cast<KeyValuePair<long, TimeSpan?>?>().ElementAtOrDefault(index + 1)?.Key,
                        default);
                    continue;
                }

                var stopWatch = new Stopwatch();
                var elapsedSum = TimeSpan.Zero;
                int runAttempt = 0;

                try
                {
                    for (runAttempt = 0; elapsedSum < TimeSpan.FromMinutes(1) && runAttempt < AttemptsMaxCount; runAttempt++)
                    {
                        await Task.Run(() =>
                            {
                                var scope = _engine.CreateScope();
                                scope.SetVariable("input_value", value);
                                _engine.Execute(prepareScript, scope);
                                stopWatch.Restart();
                                cancellationToken.ThrowIfCancellationRequested();
                                _engine.Execute(code, scope);
                                stopWatch.Stop();
                            },
                            cancellationToken);

                        elapsedSum += stopWatch.Elapsed;
                    }


                    test.Runs[value] = elapsedSum / runAttempt;
                }
                catch (Exception e)
                {
                    _logger.LogWarning(e, "Ошибка выполнения скрипта");
                }
                finally
                {
                    callback(
                        value,
                        test.Runs[value],
                        runs.Cast<KeyValuePair<long, TimeSpan?>?>().ElementAtOrDefault(index + 1)?.Key,
                        runAttempt);
                }
            }
        }

        private IEnumerable<(string Name, dynamic Value)> RunCode(
            TaskAttempt taskAttempt,
            Dictionary<string, string> parameters,
            string code)
        {
            var scope = _engine.CreateScope();
            foreach (var taskAttemptParameter in parameters)
            {
                var value = _engine.Execute($"int(\"{taskAttemptParameter.Value}\")");
                scope.SetVariable(taskAttemptParameter.Key, value);
            }

            _engine.Execute(code, scope);

            var outputVars = taskAttempt.TaskDescription.OutputVars.Select(x => (x, scope.GetVariable(x)));
            return outputVars;
        }
    }
}
