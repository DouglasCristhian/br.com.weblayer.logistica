
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

namespace br.com.weblayer.logistica.android
{
    [Activity(MainLauncher = true)]
    public class BuscaNotaViewActivity : Activity
	{
		ListView lstNota;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.buscanotaview);

            lstNota = FindViewById<ListView>(Resource.Id.NotaListView);

            var ListaNotas = new NotaFiscalManager().GetNotaFiscal("");

            lstNota.Adapter = new NotaFiscalListAdapter(this, ListaNotas);

		}
	}
}
