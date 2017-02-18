using Android.App;
using Android.Widget;
using Android.OS;
using Trinity.Control;

namespace Trinity
{
    [Activity(Label = "Trinity", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            StartActivity(typeof(LoginScreem));
        }
    }
}

