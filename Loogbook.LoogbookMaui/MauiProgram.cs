using CommunityToolkit.Maui;
using LogBook.Lib;
using LogBook.LogbookCore.Services;
using LogBook.LogbookCore.ViewModel;
using Loogbook.LoogbookCore.ViewModel;
using Loogbook.LoogbookMaui.Pages;
using Loogbook.LoogbookMaui.Services;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

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
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<ReportViewModel>();
            builder.Services.AddSingleton<ReportPage>();

            System.Diagnostics.Debug.WriteLine("Pfad: ");
            string path = FileSystem.Current.AppDataDirectory;
            string filename = "data.csv";

            string fullpath = System.IO.Path.Combine(path, filename);
            
            System.Diagnostics.Debug.WriteLine(fullpath);

            // builder.Services.AddSingleton<Irepository>(new xmlRepository(fullpath));
            builder.Services.AddSingleton<Irepository>(new Sqliterepository(fullpath));

            builder.Services.AddSingleton<IAlertService, AlertService>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
