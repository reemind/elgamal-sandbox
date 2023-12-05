using AspNet.Security.OAuth.Yandex;
using ElgamalSandbox.Core.Entities;
using ElgamalSandbox.Data.Postgres;
using Microsoft.AspNetCore.Identity;

namespace ElgamalSandbox.Web.Authorization;

public static class Entry
{
    public static IServiceCollection AddIdentityModel(this IServiceCollection services)
    {
        services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<EfContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddYandex(YandexAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.ClientId = "7500068a6ea44a3db450153a89b9564e";
                    options.ClientSecret = "b2d23748ce514b38b1690eeffaa8ff7a";
                })
            .AddIdentityCookies();


        return services;
    }
}