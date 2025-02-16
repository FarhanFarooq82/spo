using BeoRecruitment.Services;
using BeoRecruitment.ViewModels;
using BeoRecruitment.Views;
using Microsoft.Extensions.Logging;

namespace BeoRecruitment;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseViewLocater()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services
			.AddSingleton<INavigationService, NavigationService>()

			.AddTransient<MainNavigationPage>()
			.AddSingleton<ISpotifyService, SpotifyService>()

			.RegisterView<MainViewModel, MainPage>()
			.RegisterView<SearchResultViewModel, SearchResultPage>();

		return builder.Build();
	}
}
