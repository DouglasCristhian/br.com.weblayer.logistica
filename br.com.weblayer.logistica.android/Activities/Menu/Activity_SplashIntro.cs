
using Android.App;
using Android.Content;
using Android.OS;
using System.Threading.Tasks;

namespace br.com.weblayer.logistica.android.Activities.Menu
{
    [Activity(NoHistory = true, MainLauncher = true)]
    public class Activity_SplashIntro : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Activity_SplashIntro);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            await Task.Delay(4000); // Simulate a bit of startup work.
            StartActivity(new Intent(Application.Context, typeof(Activity_Login)));
        }
    }
}