﻿
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
    [Activity(MainLauncher = false, Label = "Busca Nota Fiscal")]
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

        private void FillList()
        {
            ListaNotas = new NotaFiscalManager().GetNotaFiscal("");
            ListViewNota.Adapter = new NotaFiscalListAdapter(this, ListaNotas);
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            FillList();
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        { 
            var ListViewNotaClick = sender as ListView;
            var t = ListaNotas[e.Position];

            Intent intent = new Intent();
            intent.SetClass(this, typeof(InformaEntregaActivity));
            
            //Passa a string do objeto para a próxima tela
            intent.PutExtra("JsonNota", Newtonsoft.Json.JsonConvert.SerializeObject(t));

            StartActivityForResult(intent,0);

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {

                var mensagem  = data.GetStringExtra("mensagem");
                Toast.MakeText(this, mensagem, ToastLength.Long).Show();
                
                FillList();

            }
        }
    }
}