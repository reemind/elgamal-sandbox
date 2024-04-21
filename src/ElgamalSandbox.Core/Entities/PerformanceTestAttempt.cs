﻿using ElgamalSandbox.Core.Exceptions;
using ElgamalSandbox.Core.Extensions;

namespace ElgamalSandbox.Core.Entities;

public class PerformanceTestAttempt : EntityBase
{
    public const string PerformanceTestField = nameof(_performanceTest);

    private PerformanceTest _performanceTest;

    public Dictionary<long, TimeSpan?> Runs { get; set; }

    public long PerformanceTestId { get; private set; }

    public string Name => CreatedAt.ToLocalString();

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