using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using br.com.weblayer.logistica.core.Model;
using br.com.weblayer.logistica.core.BLL;
using br.com.weblayer.logistica.android.Adapters;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(MainLauncher = false, Label = "Performance", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class Activity_Performance : Activity_Base
    {
        ListView ListViewPerformance;
        List<Performance> ListaPerformances;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Activity_Performance);

            FindViews();

            FillList();
        }

        private void FindViews()
        {
            ListViewPerformance = FindViewById<ListView>(Resource.Id.PerformanceListView);
        }

        private void FillList()
        {
            ListaPerformances = new PerformanceManager().GetPerformance();
            ListViewPerformance.Adapter = new Adapter_Performance_ListView(this, ListaPerformances);
        }
    }
}