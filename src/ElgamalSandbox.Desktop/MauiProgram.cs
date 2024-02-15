using ElgamalSandbox.Core;
using ElgamalSandbox.Data.SqLite;
using ElgamalSandbox.Desktop.Services;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;

namespace ElgamalSandbox.Desktop
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddCore();
            builder.Services.AddLogging();
            builder.Services.AddSqLite(x => x.Path = Path.Combine(
                FileSystem.AppDataDirectory,
                "Database.db3"));

            Migrate(builder.Services);

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            builder.Services.AddMudMarkdownServices();
            builder.Services.AddScoped<TaskRunner>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void Migrate(IServiceCollection serviceCollection)
        {
            using var services = serviceCollection.BuildServiceProvider();

            var migrator = services.GetRequiredService<DbMigrator>();
            migrator.MigrateAsync().GetAwaiter().GetResult();
        }
    }
}
