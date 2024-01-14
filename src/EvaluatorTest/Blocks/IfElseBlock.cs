namespace EvaluatorTest.Blocks;

public class IfElseBlock : BlockBase
{
    public ICondition Condition { get; set; }

    public IBlock TrueBlock { get; set; }

    public IBlock? ElseBlock { get; set; }


    /// <inheritdoc />
    public override IEnumerable<string> RenderRows()
        => GetWithIntent(RenderValue());

    private IEnumerable<string> RenderValue()
    {
        yield return $"if {Condition.Render()}:";

        foreach (var row in GetWithIntent(TrueBlock.RenderRows(), Intent + 1))
        {
            yield return row;
        }

        if (ElseBlock == null)
            yield break;

        yield return $"else:";

        foreach (var row in GetWithIntent(ElseBlock.RenderRows(), Intent + 1))
        {
            yield return row;
        }
    }
}