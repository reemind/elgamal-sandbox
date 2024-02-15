using ElgamalSandbox.Core.Exceptions;

namespace ElgamalSandbox.Core.Entities;

public class TaskTestAttemptRelation
{
    private TaskTest _test;
    private TaskAttempt _attempt;

    public long TestId { get; set; }

    public long AttemptId { get; set; }

    public TaskTest Test
    {
        get => _test;
        set
        {
            TestId = value?.Id ?? throw new RequiredFieldNotSpecifiedException();
            _test = value;
        }
    }

    public TaskAttempt Attempt
    {
        get => _attempt;
        set
        {
            AttemptId = value?.Id ?? throw new RequiredFieldNotSpecifiedException();
            _attempt = value;
        }
    }

    public TestResult Result { get; set; }
}

public enum TestResult
{
    Success,
    Failure,
    Skipped
}