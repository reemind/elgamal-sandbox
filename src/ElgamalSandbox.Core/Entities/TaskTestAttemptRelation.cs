using ElgamalSandbox.Core.Enums;
using ElgamalSandbox.Core.Exceptions;

namespace ElgamalSandbox.Core.Entities;

public class TaskTestAttemptRelation
{
    private TaskTest _test;
    private TaskAttempt _attempt;

    public long TestId { get; private set; }

    public long AttemptId { get; private set; }

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