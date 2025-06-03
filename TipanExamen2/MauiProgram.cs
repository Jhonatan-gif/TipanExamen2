using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace TipanExamen2
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

            // Registro de páginas para inyección (opcional)
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ChistesPage>();
            builder.Services.AddTransient<AboutPage>();

            return builder.Build();
        }
    }
}
