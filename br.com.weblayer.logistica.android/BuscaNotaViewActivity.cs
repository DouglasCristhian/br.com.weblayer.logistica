
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
using br.com.weblayer.logistica.core.BLL;
using br.com.weblayer.logistica.core.Model;

namespace br.com.weblayer.logistica.android
{
    [Activity(MainLauncher = true)]
    public class BuscaNotaViewActivity : Activity
	{
		ListView ListViewNota;
        List<NotaFiscal> ListaNotas;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState); 
			SetContentView(Resource.Layout.buscanotaview);

            Button btnPesquisar = FindViewById<Button>(Resource.Id.btnPesquisar);

            ListViewNota = FindViewById<ListView>(Resource.Id.NotaListView);
            ListViewNota.Clickable = true;

            btnPesquisar.Click += BtnPesquisar_Click;                        
            ListViewNota.ItemClick += OnListItemClick;

        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            ListaNotas = new NotaFiscalManager().GetNotaFiscal("");
            ListViewNota.Adapter = new NotaFiscalListAdapter(this, ListaNotas);
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        { 
            var ListViewNotaClick = sender as ListView;
            var t = ListaNotas[e.Position];

            Intent intent = new Intent();
            intent.SetClass(this, typeof(NotaActivity));
            
            //Passa a string do objeto para a próxima tela
            intent.PutExtra("JsonNota", Newtonsoft.Json.JsonConvert.SerializeObject(t));

            StartActivity(intent);

        }
    }
}
