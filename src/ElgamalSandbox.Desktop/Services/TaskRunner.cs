using ElgamalSandbox.Core.Abstractions;
using ElgamalSandbox.Core.Entities;
using ElgamalSandbox.Core.Enums;
using IronPython.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Scripting.Hosting;

namespace ElgamalSandbox.Desktop.Services
{
    internal class TaskRunner
    {
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
        }

        public async Task RunAsync(TaskAttempt taskAttempt)
        {
            var code = taskAttempt.TaskDescription.InputVars
                .Aggregate(
                    taskAttempt.Code,
                    (acc, cur) =>
                        acc.Replace($"{cur} = None\n", ""));

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

        private IEnumerable<(string Name, dynamic Value)> RunCode(TaskAttempt taskAttempt, Dictionary<string, string> parameters, string code)
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
