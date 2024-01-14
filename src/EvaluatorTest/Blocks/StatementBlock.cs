namespace EvaluatorTest.Blocks;

public class StatementBlock : BlockBase
{
    public List<IBlock> Blocks { get; set; }

    /// <inheritdoc />
    public override IEnumerable<string> RenderRows()
        => GetWithIntent(Blocks.SelectMany(x => x.RenderRows()));
}