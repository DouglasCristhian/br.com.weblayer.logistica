using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using br.com.weblayer.logistica.core.BLL;
using br.com.weblayer.logistica.core.Model;
using br.com.weblayer.logistica.android.Adapters;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Cidade", MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class Activity_Cidade : Activity
    {
        ListView ListViewCidades;
        List<Cidade> ListaCidades;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Activity_Cidade);

            FindViews();
            FillList();           
        }

        private void FindViews()
        {
            ListViewCidades = FindViewById<ListView>(Resource.Id.CidadeListView);
        }

        private void FillList()
        {
            ListaCidades = new CidadeManager().GetCidade();
            ListViewCidades.Adapter = new Adapter_Cidade_ListView(this, ListaCidades);
        }
    }
}