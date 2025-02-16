namespace BeoRecruitment;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var page = IPlatformApplication.Current?.Services.GetService<MainNavigationPage>();
		return new Window(page ?? throw new InvalidOperationException($@"Could not create instance of '{nameof(MainNavigationPage)}'"));
	}
}

