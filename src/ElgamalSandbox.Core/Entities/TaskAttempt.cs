using ElgamalSandbox.Core.Enums;
using ElgamalSandbox.Core.Exceptions;
using System.Text.Json.Nodes;

namespace ElgamalSandbox.Core.Entities;

public class TaskAttempt : EntityBase
{
    public const string TaskDescriptionField = nameof(_taskDescription);

    private TaskDescription _taskDescription;

    public TaskAttempt(
        string code,
        Dictionary<string, string> parameters,
        AttemptTypes type,
        TaskDescription taskDescription)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
        Parameters = parameters;
        Type = type;
        TaskDescription = taskDescription;

        Tests = new List<TaskTestAttemptRelation>();
    }

    private TaskAttempt()
    {
    }

    public string Code { get; set; }

    public JsonObject? Playground { get; set; }

    public Dictionary<string, string> Parameters { get; set; }

    public AttemptTypes Type { get; set; }

    public bool IsSucceeded { get; set; }

    public long TaskDescriptionId { get; private set; }

    public string Result { get; set; }

    public TaskDescription TaskDescription
    {
        get => _taskDescription;
        set
        {
            TaskDescriptionId = value?.Id ?? throw new RequiredFieldNotSpecifiedException("Задача");
            _taskDescription = value;
        }
    }

    public List<TaskTestAttemptRelation> Tests { get; set; }

    public bool IsPassedTests
        => Type == AttemptTypes.Test
           && Tests.Any()
           && Tests.TrueForAll(x => x.Result == TestResult.Success);
}