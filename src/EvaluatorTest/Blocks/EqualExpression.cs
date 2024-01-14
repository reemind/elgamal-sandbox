namespace EvaluatorTest.Blocks;

public class EqualExpression : ICondition
{
    private readonly string _a;
    private readonly string _b;

    public EqualExpression(string a, string b)
    {
        _a = a;
        _b = b;
    }

    /// <inheritdoc />
    public IEnumerable<string> RenderRows()
    {
        yield return $"{_a} == {_b}";
    }
}