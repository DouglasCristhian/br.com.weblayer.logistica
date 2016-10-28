using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using br.com.weblayer.logistica.core.Model;
using br.com.weblayer.logistica.core.BLL;
using Java.Lang;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Activity_TabelaResultadoFrete")]
    public class Activity_TabelaResultadoFrete : Activity_Base
    {
        private SimulacaoFrete simu;
        TextView txtTransp;
        TextView txtFret;
        TextView txtFreteImpos;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Activity_TabelaResultadoFrete);

            var dadossimulados = Intent.GetStringExtra("dadossimulacao");
            simu = Newtonsoft.Json.JsonConvert.DeserializeObject<SimulacaoFrete>(dadossimulados);     

            FindViews();
            BindData();
        }

       

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        private void FindViews()
        {
            txtTransp = FindViewById<TextView>(Resource.Id.txt1);
            txtFret = FindViewById<TextView>(Resource.Id.txt2);
            txtFreteImpos = FindViewById<TextView>(Resource.Id.txt3);
        }

        private void BindData()
        {
            txtTransp.Text = simu.ds_transportadora;
            txtFret.Text = simu.vl_frete.ToString();
            txtFreteImpos.Text = simu.vl_frete_imposto.ToString();
        }
    }
}