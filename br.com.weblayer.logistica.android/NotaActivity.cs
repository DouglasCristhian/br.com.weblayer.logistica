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

namespace br.com.weblayer.logistica.android
{
    [Activity(Label = "NotaActivity")]
    public class NotaActivity : Activity
    {
        private TextView txtNomeCliente;
        private TextView txtValor;
        private TextView txtNotaSerie;
        private EditText txtDataEntrega;
        private Button ConfirmarEntrega;
        public DatePicker dateTimePicker;

        private NotaFiscal nota;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NotaView);

            //string da nota
            var jsonnota= Intent.GetStringExtra("JsonNota");

            //transforma a string no objeto
            nota = Newtonsoft.Json.JsonConvert.DeserializeObject<NotaFiscal>(jsonnota);

            FindViews();
            BindData();

        }

        private void FindViews()
        {
            
            txtNomeCliente = FindViewById <TextView>(Resource.Id.txtNomeCliente);
            txtValor = FindViewById<TextView>(Resource.Id.txtValorNota);
            txtNotaSerie = FindViewById<TextView>(Resource.Id.txtNotaSerie);
            txtDataEntrega = FindViewById<EditText>(Resource.Id.txtDataa);
            ConfirmarEntrega = FindViewById<Button>(Resource.Id.btnConfirmarEntrega);
        }

        private void BindData()
        {
            txtNomeCliente.Text = nota.ds_cliente;
            txtNotaSerie.Text = nota.ds_numeronota;
            txtValor.Text = nota.ds_serienota;
           // txtDataEntrega.Text = nota.dt_entrega;
        }
    }
}