using Microsoft.Extensions.Logging;

namespace GestaoEmpresarial
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
					fonts.AddFont("Roboto-Light.ttf", "RobotoL");
					fonts.AddFont("Roboto-Regular.ttf", "RobotoR");
					fonts.AddFont("SpaceGrotesk-Bold.ttf", "SpaceB");
					fonts.AddFont("SpaceGrotesk-Medium.ttf", "SpaceM");
					fonts.AddFont("SpaceGrotesk-Regular.ttf", "SpaceR");
					fonts.AddFont("SpaceGrotesk-SemiBold.ttf", "SpaceS");
					fonts.AddFont("icons.ttf", "Icons");
					fonts.AddFont("Nexa-ExtraLight.ttf", "NexaE");
					fonts.AddFont("Nexa-Heavy.ttf", "NexaH");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
