namespace EvaluatorTest.Blocks;

public abstract class BlockBase : IBlock
{
    public int Intent { get; set; }

    /// <inheritdoc />
    public abstract IEnumerable<string> RenderRows();

    public IEnumerable<string> GetWithIntent(IEnumerable<string> source, int? indent = null)
        => source.Select(x => new string('\t', indent ?? Intent) + x);
}