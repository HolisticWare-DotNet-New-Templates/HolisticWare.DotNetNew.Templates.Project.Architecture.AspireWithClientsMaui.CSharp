﻿namespace ClientAppsIntegration.MAUI.Blazor;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
}
