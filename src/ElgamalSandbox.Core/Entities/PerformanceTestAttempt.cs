using ElgamalSandbox.Core.Exceptions;

namespace ElgamalSandbox.Core.Entities;

public class PerformanceTestAttempt : EntityBase
{
    public const string PerformanceTestField = nameof(_performanceTest);

    private PerformanceTest _performanceTest;

    public PerformanceTestAttempt()
    {
    }

    public Dictionary<long, TimeSpan?> Runs { get; set; }

    public long PerformanceTestId { get; set; }

    public string Name => $"{CreatedAt:dd.MM.yyyy hh:mm}";

    public PerformanceTest PerformanceTest
    {
        get => _performanceTest;
        set
        {
            PerformanceTestId = value?.Id ?? throw new RequiredFieldNotSpecifiedException("Задача");
            _performanceTest = value;
        }
    }
}