using Microsoft.Extensions.Logging;

namespace Registro
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Poppins-Black.ttf", "loster");
					fonts.AddFont("Poppins-ExtraLight.ttf", "loster2");
					fonts.AddFont("Poppins-BlackItalic.ttf", "loster3");
					fonts.AddFont("Poppins-ExtraLight.ttf", "loster4");
				});

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
