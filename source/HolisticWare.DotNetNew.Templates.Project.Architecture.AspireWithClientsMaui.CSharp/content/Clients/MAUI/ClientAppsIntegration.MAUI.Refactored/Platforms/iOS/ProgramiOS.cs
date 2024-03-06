using ObjCRuntime;
using UIKit;

namespace ClientAppsIntegration.MAUI
{
    public class ProgramiOS
    {
        // This is the main entry point of the application.
        internal static void MainiOS(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}
