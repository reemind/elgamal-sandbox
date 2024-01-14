using EvaluatorTest.Blocks;
using Microsoft.Scripting.Hosting;

namespace EvaluatorTest;

public class Task
{
    private readonly ScriptEngine _engine;

    public Task(ScriptEngine engine)
    {
        _engine = engine;
    }

    public string[] Params { get; set; }

    public object[][] Values { get; set; }

    public IBlock Block { get; set; }

    public IEnumerable<string> Run()
    {
        var code = $"def ev({string.Join(',', Params)}):\n"
                   + string.Join('\n', Block.RenderRows());

        var scope = _engine.CreateScope();

        _engine.Execute(code, scope);

        var func = scope.GetVariable("ev");

        foreach (var value in Values)
        {
            yield return _engine.Operations.Invoke(func, value);
        }
    }
}