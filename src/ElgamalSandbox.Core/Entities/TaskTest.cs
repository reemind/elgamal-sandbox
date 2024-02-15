using ElgamalSandbox.Core.Exceptions;

namespace ElgamalSandbox.Core.Entities;

public class TaskTest : EntityBase
{
    public const string TaskField = nameof(_task);

    private TaskDescription _task;

    public Dictionary<string, string> InputVars { get; set; }

    public Dictionary<string, string> OutputVars { get; set; }

    public long TaskId { get; set; }

    public TaskDescription Task
    {
        get => _task;
        set
        {
            TaskId = value?.Id ?? throw new RequiredFieldNotSpecifiedException("Задача");
            _task = value;
        }
    }

    public List<TaskTestAttemptRelation> Attempts { get; set; }
}