using ElgamalSandbox.Core.Entities;

namespace ElgamalSandbox.Web.Authorization;

public static class Entry
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(options =>
        {

        });

        services.AddAuthorization()
            .Add
        return services;
    }
}