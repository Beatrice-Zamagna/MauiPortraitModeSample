using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PortaitModeSample;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        var orientation = DeviceDisplay.MainDisplayInfo.Orientation;
        Preferences.Set("AppOrientation", orientation.ToString());

        RequestedOrientation = ScreenOrientation.Locked;
    }
}
