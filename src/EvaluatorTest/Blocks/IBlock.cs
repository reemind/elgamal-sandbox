namespace EvaluatorTest.Blocks;

public interface IBlock
{
    string Render()
        => string.Concat(RenderRows());

    IEnumerable<string> RenderRows();
}