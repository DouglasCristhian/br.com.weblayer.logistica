using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using br.com.weblayer.logistica.android.Adapters;
using br.com.weblayer.logistica.core.BLL;
using br.com.weblayer.logistica.core.Model;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(MainLauncher = true, Label = "Busca Nota Fiscal", ConfigurationChanges=Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]

    public class Activity_BuscaNotaView : Activity
	{
		ListView ListViewNota;
        List<NotaFiscal> ListaNotas;
        Button btnPesquisar;
        EditText txtNumNota;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState); 
			SetContentView(Resource.Layout.Activity_BuscaNotaView);

            ListViewNota = FindViewById<ListView>(Resource.Id.NotaListView);

            FindViews();

            btnPesquisar.Click += BtnPesquisar_Click;                        
            ListViewNota.ItemClick += OnListItemClick;
        }

        private void FindViews()
        {
            btnPesquisar = FindViewById<Button>(Resource.Id.btnPesquisar);
            txtNumNota = FindViewById<EditText>(Resource.Id.txtNumNota);
        }

        private bool ValidateViews()
        {
            var validacao = true;
            if (txtNumNota.Length() == 0)
            {
                validacao = false;
                txtNumNota.Error = "Número da nota inválido!";
            }

            return validacao;

        }

        private void FillList()
        {
            ListaNotas = new NotaFiscalManager().GetNotaFiscal("");
            ListViewNota.Adapter = new Adapter_NotaFiscal_ListView(this, ListaNotas);
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (!ValidateViews())
                return;

            FillList();
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        { 
            var ListViewNotaClick = sender as ListView;
            var t = ListaNotas[e.Position];

            Intent intent = new Intent();
            intent.SetClass(this, typeof(Activity_InformaEntrega));
            
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
