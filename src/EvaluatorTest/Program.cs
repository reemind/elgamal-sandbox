using EvaluatorTest.Blocks;
using IronPython.Hosting;

namespace EvaluatorTest
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var engine = Python.CreateEngine();

            var result = new Task(engine)
            {
                Block = new StatementBlock
                {
                    Intent = 1,
                    Blocks = new List<IBlock>
                    {
                        new ConstantBlock("x = 1"),
                        new WhileBlock()
                        {
                            Condition = new EqualExpression("not x", "((a**x) % n)"),
                            Block = new StatementBlock()
                            {
                                Blocks = new List<IBlock>()
                                {
                                    new ConstantBlock("x = x+1")
                                }
                            }
                        },
                        new ConstantBlock("return str(x)"),
                    },
                },
                Params = new[] { "y", "a", "n", },
                Values = new Object[][]
                {
                    new Object[]{ 60, 6, 5 },
                },
            }.Run().ToList();
        }
    }
}
