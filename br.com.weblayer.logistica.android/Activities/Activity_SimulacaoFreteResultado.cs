using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using br.com.weblayer.logistica.core.Model;
using br.com.weblayer.logistica.core.BLL;
using br.com.weblayer.logistica.android.Adapters;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Activity_ResultadoSimulacaoFrete", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class Activity_SimulacaoFreteResultado : Activity
    {
        ListView ListViewResult;
        List<SimulacaoFrete> ListaSimulacao;
        //EditText txtorigem;
        //EditText txtdestino;
        //EditText txtnometransp;
        //EditText txtfrete;
        //EditText txtfreteimp;
        //private SimulacaoFrete sim;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Activity_SimulacaoFreteResultado);
            FindViews();
            BindData();
        }

        private void FindViews()
        {
            ListViewResult = FindViewById<ListView>(Resource.Id.lstResultadoSimulacaoFrete);
            //txtorigem = FindViewById<EditText>(Resource.Id.txtOrigem);
            //txtdestino = FindViewById<EditText>(Resource.Id.txtDestino);
            //txtnometransp = FindViewById<EditText>(Resource.Id.txtNomeTransportadora);
            //txtfrete = FindViewById<EditText>(Resource.Id.txtFrete);
            //txtfreteimp = FindViewById<EditText>(Resource.Id.txtFreteImposto);
        }

        private void BindData()
        {
            ListaSimulacao = new SimulacaoFreteManager().GetSimulacaoFrete("","",0,0,0);
            ListViewResult.Adapter = new Adapter_SimulacaoFrete_ListView(this, ListaSimulacao);

            //txtnometransp.Text = sim.ds_transportadora;
            //txtfrete.Text = sim.vl_frete.ToString();
            //txtfreteimp.Text = sim.vl_frete_imposto.ToString();           
        }

        private void FillList()
        {
            //ListaSimulacao = new SimulacaoFreteManager().GetSimulacaoFrete();
            //ListViewResult.Adapter = new Adapter_SimulacaoFrete_ListView(this, ListaSimulacao);
        }
    }
}
