using ElgamalSandbox.Core.Exceptions;

namespace ElgamalSandbox.Core.Entities;

public class PerformanceTest : EntityBase
{
    public const string TaskDescriptionField = nameof(_taskDescription);

    private TaskDescription _taskDescription;

    public PerformanceTest()
    {
        Attempts = new List<PerformanceTestAttempt>();
    }

    public long TaskDescriptionId { get; set; }

    public TaskDescription TaskDescription
    {
        get => _taskDescription;
        set
        {
            TaskDescriptionId = value?.Id ?? throw new RequiredFieldNotSpecifiedException("Задача");
            _taskDescription = value;
        }
    }

    public List<PerformanceTestAttempt> Attempts { get; set; }
    public string PrepareScript { get; set; }
}