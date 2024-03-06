using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace ClientAppsIntegration.MAUI
{
    internal class ProgramTizen : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        internal static void MainTizen(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
