using System.Text.Json.Nodes;

namespace ElgamalSandbox.Core.Entities;

public class TaskDescription
{
    public JsonObject Toolbox { get; set; }

    public string[] InputVars { get; set; }

    public string[] OutputVars { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}