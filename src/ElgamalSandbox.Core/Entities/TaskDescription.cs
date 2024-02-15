using System.Text.Json.Nodes;

namespace ElgamalSandbox.Core.Entities;

public class TaskDescription : EntityBase
{
    public JsonObject Toolbox { get; set; }

    public string[] InputVars { get; set; }

    public string[] OutputVars { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string? Playground { get; set; }

    public List<TaskAttempt> Attempts { get; set; }

    public List<TaskTest> Tests { get; set; }
}