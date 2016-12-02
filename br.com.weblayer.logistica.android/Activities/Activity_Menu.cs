using System;
using Android.App;
using Android.OS;
using Android.Widget;

using br.com.weblayer.logistica.core.BLL;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(MainLauncher = true)]
    public class Activity_Menu : Activity
    {
        TextView lblusuario;
        Android.Support.V7.Widget.Toolbar toolbar;
        private Button btnInformarEntrega;
        private Button btnPerformance;
        private Button btnSimularFrete;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Activity_Menu);

            FindViews();
            BindData();
        }

        private void BtnInformarEntrega_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(Activity_BuscaNotaView));
        }

        private void BtnPerformance_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Activity_Performance));
        }

        private void BtnSimularFrete_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Activity_SimularFrete));
        }

        private void FindViews()
        {
            lblusuario = FindViewById<TextView>(Resource.Id.lblMenuUsuario);
            btnInformarEntrega = FindViewById<Button>(Resource.Id.btnMenuInformaEntrega);
            btnPerformance = FindViewById<Button>(Resource.Id.btnMenuPerformanceEntrega);
            btnSimularFrete = FindViewById<Button>(Resource.Id.btnMenuSimularFrete);
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
        }

        private void BindData()
        {
            toolbar.Title = "Home Page";
            toolbar.InflateMenu(Resource.Menu.menu_toolbarvazia);
            toolbar.MenuItemClick += Toolbar_MenuItemClick;

            btnInformarEntrega.Click += BtnInformarEntrega_Click;
            btnPerformance.Click += BtnPerformance_Click;
            btnSimularFrete.Click += BtnSimularFrete_Click;
        }

        private void Toolbar_MenuItemClick(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.finish:
                    Finish();
                    //Toast.MakeText(this, "discard", ToastLength.Short).Show();
                    break;


            }
        }
    }
}
