using ElgamalSandbox.Core;
using ElgamalSandbox.Core.Abstractions;
using ElgamalSandbox.Core.Entities;
using ElgamalSandbox.Data.Postgres;
using ElgamalSandbox.Web.Authorization;
using ElgamalSandbox.Web.Components;
using ElgamalSandbox.Web.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;

namespace ElgamalSandbox.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddCore();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

            builder.Services.AddPostgreSql(x => x.ConnectionString = builder.Configuration["Application:DbConnectionString"]);
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddIdentityModel();
            builder.Services.AddScoped<IUserContext, UserContext>();
            builder.Services.AddMudServices();

            builder.Services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();

            await using (var serviceProvider = builder.Services.BuildServiceProvider())
            {
                var migrator = serviceProvider.GetRequiredService<DbMigrator>();
                await migrator.MigrateAsync();
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client.UserInfo).Assembly);

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            await app.RunAsync();
        }
    }
}
