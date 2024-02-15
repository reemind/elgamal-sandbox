namespace ElgamalSandbox.Core.Abstractions;

public interface IDbSeeder
{
    public Task SeedAsync(CancellationToken cancellationToken = default);
}