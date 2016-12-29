using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using br.com.weblayer.logistica.core.Model;
using Android.Views;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Resultado da Simulação", MainLauncher = false)]
    public class Activity_TabelaResultadoFrete : Activity_Base
    {
        Android.Support.V7.Widget.Toolbar toolbar;
        private SimulacaoFrete simu;
        TextView txtTransp;
        TextView txtFret;
        TextView txtFreteImpos;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.Activity_TabelaResultadoFrete;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var dadossimulados = Intent.GetStringExtra("dadossimulacao");
            simu = Newtonsoft.Json.JsonConvert.DeserializeObject<SimulacaoFrete>(dadossimulados);     

            FindViews();
            BindData();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_toolbarvazia, menu);
            return true;
        }

        private void FindViews()
        {
            txtTransp = FindViewById<TextView>(Resource.Id.txt1);
            txtFret = FindViewById<TextView>(Resource.Id.txt2);
            txtFreteImpos = FindViewById<TextView>(Resource.Id.txt3);

            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "";
            toolbar.InflateMenu(Resource.Menu.menu_toolbarvazia);
        }

        private void BindData()
        {
            txtTransp.Text = simu.ds_transportadora;
            txtFret.Text = simu.vl_frete.ToString();
            //txtFreteImpos.Text = simu.vl_frete_imposto.ToString();
            txtFreteImpos.Text = simu.ds_memoriacalculo_clear;

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