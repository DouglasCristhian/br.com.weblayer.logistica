using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Views;
using br.com.weblayer.logistica.core.BLL;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(MainLauncher = false)]
    public class Activity_Menu : Activity
    {
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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_toolbarvazia, menu);
            return true;
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
            btnInformarEntrega = FindViewById<Button>(Resource.Id.btnMenuInformaEntrega);
            btnPerformance = FindViewById<Button>(Resource.Id.btnMenuPerformanceEntrega);
            btnSimularFrete = FindViewById<Button>(Resource.Id.btnMenuSimularFrete);

            if (UsuarioManager.Instance.usuario.ds_perfil=="TRANSPORTADOR")
                btnSimularFrete.Visibility = ViewStates.Gone;
            
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = " W/Embarcador";
            toolbar.SetLogo(Resource.Mipmap.ic_menu);
            toolbar.InflateMenu(Resource.Menu.menu_toolbarvazia);           
        }

        private void BindData()
        {        
            btnInformarEntrega.Click += BtnInformarEntrega_Click;
            btnPerformance.Click += BtnPerformance_Click;
            btnSimularFrete.Click += BtnSimularFrete_Click;
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
