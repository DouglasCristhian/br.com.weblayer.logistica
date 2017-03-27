using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using br.com.weblayer.logistica.android.Adapters;
using br.com.weblayer.logistica.core.BLL;
using br.com.weblayer.logistica.core.Model;
using System;
using System.Collections.Generic;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(MainLauncher = false, ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class Activity_Performance : Activity_Base
    {
        ListView ListViewPerformance;
        List<Performance> ListaPerformances;
        Android.Support.V7.Widget.Toolbar toolbar;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.Activity_Performance;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FindViews();
            FillList();
        }

        private void FindViews()
        {
            ListViewPerformance = FindViewById<ListView>(Resource.Id.PerformanceListView);

            GetToolbar();
            this.Title = "Performance (" + DateTime.Now.ToString("MM/yyyy") + ")";
        }

        private void GetToolbar()
        {
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.menu_toolbar);
            toolbar.Menu.RemoveItem(Resource.Id.action_sobre);
        }

        private void FillList()
        {
            ListaPerformances = new PerformanceManager().GetPerformance(1, 1);
            ListViewPerformance.Adapter = new Adapter_Performance_ListView(this, ListaPerformances);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();

                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}