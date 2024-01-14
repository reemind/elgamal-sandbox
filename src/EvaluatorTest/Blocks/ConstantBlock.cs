namespace EvaluatorTest.Blocks;

public class ConstantBlock : IBlock
{
    private readonly string _value;

    public ConstantBlock(string value)
    {
        _value = value;
    }

    /// <inheritdoc />
    public IEnumerable<string> RenderRows()
    {
        yield return _value;
    }
}