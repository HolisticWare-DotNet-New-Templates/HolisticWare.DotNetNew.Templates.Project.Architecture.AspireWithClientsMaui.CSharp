namespace ClientAppsIntegration.MAUI.Simple;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
