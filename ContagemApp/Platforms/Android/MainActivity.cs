using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ContagemApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override async void OnCreate(Bundle instance)
    {
        base.OnCreate(instance);
        Acr.UserDialogs.UserDialogs.Init(this);
    }
}
