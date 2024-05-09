using ElgamalSandbox.Core.Abstractions;
using ElgamalSandbox.Core.Entities;
using ElgamalSandbox.Core.Extensions;
using ElgamalSandbox.Core.Models;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ElgamalSandbox.Core.Services;

public class DbSeeder : IDbSeeder
{
    private static readonly Assembly Assembly = Assembly.GetAssembly(typeof(DbSeeder))!;
    private readonly IDbContext _dbContext;

    public DbSeeder(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        var number = new AutoCounter<int>(1);
        var taskTestIdCounter = new AutoCounter<long>(1);
        var performanceTestIdCounter = new AutoCounter<long>(1);
        var prepareScript = """
                            import struct
                            import random
                            from Crypto.Util import number

                            def generate_prime_number(bits):
                                return number.getPrime(bits)

                            def generate_key_pair(bits):
                                p = generate_prime_number(bits)
                                g = random.randint(2, p - 1)
                                x = random.randint(2, p - 2)
                                y = pow(g, x, p)
                                return (p, g, y), x

                            # Генерация ключей с заданной длиной
                            (n, a, y), _ = generate_key_pair(input_value)

                            """;

        // 1
        await InsertTaskAsync(
            number: number,
            name: "Реализовать дискретное возведение в степень по модулю в блочном виде",
            inputVars: ["x", "a", "n"],
            outputVars: ["y"],
            "First",
            "First",
            testIdCounter: taskTestIdCounter,
            performanceTestIdCounter: performanceTestIdCounter,
            tests: [
                new TestModel(
                    InputVars: new
                    {
                        x = 1030,
                        a = 5,
                        n = 2017,
                    },
                    OutputVars: new
                    {
                        y = 3,
                    }),
            ]);

        // 2
        await InsertTaskAsync(
            number: number,
            name: "Разработать блочную программу проверки числа на простоту",
            inputVars: ["n"],
            outputVars: ["is_prime"],
            "First",
            "Second",
            testIdCounter: taskTestIdCounter,
            performanceTestIdCounter: performanceTestIdCounter,
            tests: [
                new TestModel(
                    InputVars: new
                    {
                        n = 53,
                    },
                    OutputVars: new
                    {
                        is_prime = true,
                    }),
            ]);

        // 3
        await InsertTaskAsync(
            number: number,
            name: "Реализация шифрования Эль-Гамаля с использованием ключей",
            inputVars: ["y", "a", "m", "k", "n"],
            outputVars: ["a", "b"],
            "First",
            "Third",
            testIdCounter: taskTestIdCounter,
            performanceTestIdCounter: performanceTestIdCounter,
            tests: [
                new TestModel(
                    InputVars: new
                    {
                        y = 3,
                        a = 2,
                        m = 5,
                        k = 9,
                        n = 11,
                    },
                    OutputVars: new
                    {
                        a = 6,
                        b = 9
                    }),
            ]);

        // 4
        await InsertTaskAsync(
            number: number,
            name: "Реализация дешифрования Эль-Гамаля с использованием ключей",
            inputVars: ["x", "n", "a", "b"],
            outputVars: ["m"],
            "First",
            "Fourth",
            testIdCounter: taskTestIdCounter,
            performanceTestIdCounter: performanceTestIdCounter,
            tests: [
                new TestModel(
                    InputVars: new
                    {
                        x = 8,
                        n = 11,
                        a = 6,
                        b = 9
                    },
                    OutputVars: new
                    {
                        m = 5,
                    }),
            ]);

        // 5
        await InsertTaskAsync(
            number: number,
            name: "Реализация дискретного логарифма по модулю методом грубой силы в блочном виде",
            inputVars: ["y", "a", "n"],
            outputVars: ["x"],
            "First",
            "Fifth",
            testIdCounter: taskTestIdCounter,
            performanceTestIdCounter: performanceTestIdCounter,
            tests: [
                new TestModel(
                    InputVars: new
                    {
                        y = 6642,
                        a = 456456,
                        n = 43234,
                    },
                    OutputVars: new
                    {
                        x = 1106,
                    }),
                new TestModel(
                    InputVars: new
                    {
                        y = 863,
                        a = 789012,
                        n = 34567,
                    },
                    OutputVars: new
                    {
                        x = 34566,
                    }),

                new TestModel(
                    InputVars: new
                    {
                        y = 987654,
                        a = 567890,
                        n = 12345,
                    },
                    OutputVars: new
                    {
                        x = 12344,
                    }),

                new TestModel(
                    InputVars: new
                    {
                        y = 876543,
                        a = 345678,
                        n = 23456,
                    },
                    OutputVars: new
                    {
                        x = 23455,
                    }),

                new TestModel(
                    InputVars: new
                    {
                        y = 654321,
                        a = 210987,
                        n = 54321,
                    },
                    OutputVars: new
                    {
                        x = 54320,
                    }),

                new TestModel(
                    InputVars: new
                    {
                        y = 543210,
                        a = 109876,
                        n = 65432,
                    },
                    OutputVars: new
                    {
                        x = 65431,
                    })

            ],
            performanceTests: [
                new PerformanceTest(prepareScript)
                ]);

        // 6
        await InsertTaskAsync(
            number: number,
            name: "Реализация дискретного логарифма по модулю с использованием алгоритма \"Шаг младенца - шаг гиганта\"",
            inputVars: ["y", "a", "n"],
            outputVars: ["x"],
            "First",
            description: "Sixth",
            testIdCounter: taskTestIdCounter,
            performanceTestIdCounter: performanceTestIdCounter,
            tests: [
                new TestModel(
                    InputVars: new
                    {
                        y = 3,
                        a = 5,
                        n = 2017,
                    },
                    OutputVars: new
                    {
                        x = 1030,
                    }),
            ],
            performanceTests: [
                new PerformanceTest(prepareScript),
            ]);


        // 7
        await InsertTaskAsync(
            number: number,
            name: "Разработать блочную программу для нахождения дискретного логарифма по модулю с использованием алгоритма Полига-Хеллмана",
            inputVars: ["y", "a", "n"],
            outputVars: ["x"],
            "First",
            description: "Sixth",
            testIdCounter: taskTestIdCounter,
            performanceTestIdCounter: performanceTestIdCounter,
            tests: [
                new TestModel(
                    InputVars: new
                    {
                        y = 3,
                        a = 5,
                        n = 2017,
                    },
                    OutputVars: new
                    {
                        x = 1030,
                    }),
            ],
            performanceTests: [
                new PerformanceTest(prepareScript),
            ]);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task InsertTaskAsync(
        int number,
        string name,
        string[] inputVars,
        string[] outputVars,
        string toolboxFileName,
        string description,
        AutoCounter<long> testIdCounter,
        AutoCounter<long> performanceTestIdCounter,
        List<TestModel> tests,
        List<PerformanceTest>? performanceTests = null)
    {
        var task = new TaskDescription
        {
            Id = number,
            Number = number,
            Name = name,
            Description = await new StreamReader(
                    GetStream($"ElgamalSandbox.Core.Descriptions.{description}.md"))
                .ReadToEndAsync(),
            InputVars = inputVars,
            OutputVars = outputVars,
            Toolbox = (await JsonSerializer.DeserializeAsync<JsonObject>(
                GetStream($"ElgamalSandbox.Core.Toolboxes.{toolboxFileName}.json")))!,
        };

        await _dbContext.TaskDescriptions.MutateAsync(task);

        await _dbContext.TaskTests.MutateAsync(
            tests.Select(x => new TaskTest()
            {
                Id = testIdCounter,
                Task = task,
                InputVars = ToPropertiesDictionary(x.InputVars),
                OutputVars = ToPropertiesDictionary(x.OutputVars)
            }));

        if (performanceTests is not null)
        {
            performanceTests.ForEach(x =>
            {
                x.Id = performanceTestIdCounter;
                x.TaskDescription = task;
            });
            await _dbContext.PerformanceTests.MutateAsync(performanceTests);
        }
    }

    private Dictionary<string, string> ToPropertiesDictionary(object instance)
        => instance.GetType()
            .GetProperties()
            .ToDictionary(x => x.Name, x => x.GetValue(instance)!.ToString()!);

    private Stream GetStream(string fileName)
        => Assembly.GetManifestResourceStream(fileName)!;

    private record TestModel(object InputVars, object OutputVars);
}