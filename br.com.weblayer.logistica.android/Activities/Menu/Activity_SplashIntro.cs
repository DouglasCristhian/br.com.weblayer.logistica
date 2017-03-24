
using Android.App;
using Android.Content;
using Android.OS;
using System.Threading.Tasks;

namespace br.com.weblayer.logistica.android.Activities.Menu
{
    [Activity(Theme = "@style/MyTheme.Splash", NoHistory = true, MainLauncher = true)]
    public class Activity_SplashIntro : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        async void SimulateStartup()
        {
            await Task.Delay(4000); 
            StartActivity(new Intent(Application.Context, typeof(Activity_Login)));
        }
    }
}