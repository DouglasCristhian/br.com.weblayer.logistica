using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using br.com.weblayer.logistica.core.Model;
using br.com.weblayer.logistica.core.BLL;
using br.com.weblayer.logistica.android.Adapters;
using Android.Content;
using Android.Views;
using System.Runtime.Remoting.Contexts;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Resultado da Simulação", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class Activity_SimulacaoFreteResultado : Activity_Base
    {
        ListView ListViewResult;
        List<SimulacaoFrete> ListaSimulacao;
        TextView EmpytText;
        Android.Support.V7.Widget.Toolbar toolbar;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.Activity_SimulacaoFreteResultado;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FindViews();
            BindData();
        }

        private void FindViews()
        {
            ListViewResult = FindViewById<ListView>(Resource.Id.lstResultadoSimulacaoFrete);
            EmpytText = FindViewById<TextView>(Resource.Id.txtListEmpty);

            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Resultado da Simulação";
            toolbar.InflateMenu(Resource.Menu.menu_toolbarvazia);
        }

        private void BindData()
        {

            var simulafrete = new SimulacaoFreteManager();

            ListaSimulacao = simulafrete.GetSimulacaoFrete("3513801", "3534401", 100, 5, 20);
            
            ListViewResult.Adapter = new Adapter_SimulacaoFrete_ListView(this, ListaSimulacao);
            ListViewResult.ItemClick += OnListItemClick;
            EmpytText.Text = simulafrete.mensagem;
            ListViewResult.EmptyView = EmpytText;
             

        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var ListViewSimulacaoFrete = sender as ListView;
            var l = ListaSimulacao[e.Position];

            Intent intent = new Intent();
            intent.SetClass(this, typeof(Activity_TabelaResultadoFrete));
            intent.PutExtra("dadossimulacao", Newtonsoft.Json.JsonConvert.SerializeObject(l));

            StartActivity(intent);

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
