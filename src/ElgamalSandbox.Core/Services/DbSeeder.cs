using ElgamalSandbox.Core.Abstractions;
using ElgamalSandbox.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ElgamalSandbox.Core.Services;

public class DbSeeder : IDbSeeder
{
    private readonly IDbContext _dbContext;

    public DbSeeder(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        // 1
        await InsertTaskAsync(
            number: 1,
            name: "Реализовать дискретный логарифм по модулю в блочном виде",
            inputVars: new[] { "y", "a", "n" },
            outputVars: new[] { "x" },
            "First",
            "First",
            tests: [
                new TaskTest()
                {
                    InputVars = new Dictionary<string, string>
                    {
                        { "y", "1" }, { "a", "1" }, { "n", "1" }
                    },
                    OutputVars = new Dictionary<string, string>
                    {
                        { "x", "8" },
                    },
                }
            ]);

        // 2
        await InsertTaskAsync(
            number: 2,
            name: "Разработать блочную программу для генерации ключей",
            inputVars: new[] { "y", "a", "n" },
            outputVars: new[] { "x" },
            "First",
            "Second",
            tests: [
                new TaskTest()
                {
                    InputVars = new Dictionary<string, string>
                    {
                        { "y", "1" }, { "a", "1" }, { "n", "1" }
                    },
                    OutputVars = new Dictionary<string, string>
                    {
                        { "x", "8" },
                    },
                }
            ]);

        // 3
        await InsertTaskAsync(
            number: 3,
            name: "Реализация шифрования ElGamal с использованием ключей",
            inputVars: new[] { "y", "a", "n" },
            outputVars: new[] { "x" },
            "First",
            "Third",
            tests: [
                new TaskTest()
                {
                    InputVars = new Dictionary<string, string>
                    {
                        { "y", "1" }, { "a", "1" }, { "n", "1" }
                    },
                    OutputVars = new Dictionary<string, string>
                    {
                        { "x", "8" },
                    },
                }
            ]);

        // 4
        await InsertTaskAsync(
            number: 4,
            name: "Реализация дискретного логарифма по модулю грубой силы в блочном виде",
            inputVars: new[] { "y", "a", "n" },
            outputVars: new[] { "x" },
            "First",
            "Second",
            tests: [
                new TaskTest()
                {
                    InputVars = new Dictionary<string, string>
                    {
                        { "y", "1" }, { "a", "1" }, { "n", "1" }
                    },
                    OutputVars = new Dictionary<string, string>
                    {
                        { "x", "8" },
                    },
                }
            ],
            performanceTests: [
                new PerformanceTest()
                {
                    PrepareScript = """
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
                                    
                                    """
                }
                ]);

        await InsertTaskAsync(
            number: 5,
            name: "Реализация дискретного логарифма по модулю с использованием алгоритма \"Шаг младенца - шаг гиганта\"",
            inputVars: new[] { "g", "a", "p" },
            outputVars: new[] { "x" },
            "First",
            description: "Fifth",
            tests: [
                new TaskTest()
                {
                    InputVars = new Dictionary<string, string>
                    {
                        { "g", "2" }, { "a", "16190" }, { "p", "30803" }
                    },
                    OutputVars = new Dictionary<string, string>
                    {
                        { "x", "12345" },
                    },
                }
            ]);


        await InsertTaskAsync(
            number: 6,
            name: "Разработать блочную программу для нахождения дискретного логарифма по модулю с использованием алгоритма Полига-Хеллмана",
            inputVars: new[] { "g", "a", "p" },
            outputVars: new[] { "x" },
            "First",
            description: "Sixth",
            tests: [
                new TaskTest()
                {
                    InputVars = new Dictionary<string, string>
                    {
                        { "g", "2" }, { "a", "16190" }, { "p", "30803" }
                    },
                    OutputVars = new Dictionary<string, string>
                    {
                        { "x", "12345" },
                    },
                }
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
        List<TaskTest> tests,
        List<PerformanceTest>? performanceTests = null)
    {
        var task = _dbContext.TaskDescriptions
            .Include(x => x.Tests)
            .Include(x => x.PerformanceTests)
            .FirstOrDefault(x => x.Number == number);

        if (task == null)
            _dbContext.TaskDescriptions.Add(task = new TaskDescription());

        var assembly = Assembly.GetAssembly(typeof(DbSeeder));

        task.Number = number;
        task.Name = name;
        task.Description = await new StreamReader(
                assembly.GetManifestResourceStream($"ElgamalSandbox.Core.Descriptions.{description}.md"))
            .ReadToEndAsync();
        task.InputVars = inputVars;
        task.OutputVars = outputVars;


        var stream = assembly
            .GetManifestResourceStream($"ElgamalSandbox.Core.Toolboxes.{toolboxFileName}.json");

        task.Toolbox = await JsonSerializer.DeserializeAsync<JsonObject>(stream);

        //task.Tests = tests;

        if (performanceTests is not null)
        {
            task.PerformanceTests.Clear();
            task.PerformanceTests.AddRange(performanceTests);
        }
    }
}