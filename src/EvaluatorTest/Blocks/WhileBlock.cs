namespace EvaluatorTest.Blocks;

public class WhileBlock : BlockBase
{
    public ICondition Condition { get; set; }

    public IBlock Block { get; set; }


    /// <inheritdoc />
    public override IEnumerable<string> RenderRows()
        => GetWithIntent(RenderValue());

    private IEnumerable<string> RenderValue()
    {
        yield return $"while {Condition.Render()}:";

        foreach (var row in GetWithIntent(Block.RenderRows(), Intent + 1))
        {
            yield return row;
        }
    }
}