using CommunityToolkit.Maui;
using LogBook.Lib;
using Loogbook.LoogbookMaui.ViewModel;
using Microsoft.Extensions.Logging;

namespace Loogbook.LoogbookMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

            System.Diagnostics.Debug.WriteLine("Pfad: ");
            string path = FileSystem.Current.AppDataDirectory;
            string filename = "data.xml";

            string fullpath = System.IO.Path.Combine(path, filename);
            
            System.Diagnostics.Debug.WriteLine(fullpath);

            builder.Services.AddSingleton<Irepository>(new xmlRepository(fullpath));
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
