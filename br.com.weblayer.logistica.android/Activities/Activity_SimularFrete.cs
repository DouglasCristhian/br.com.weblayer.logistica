using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using br.com.weblayer.logistica.core.Model;
using br.com.weblayer.logistica.core.BLL;
using br.com.weblayer.logistica.android.Adapters;
using static Android.Resource;
using System;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Simula��o do Frete", MainLauncher = true)]
    public class Activity_SimularFrete : Activity
    {
        EditText txtOrigem;
        EditText txtDestino;
        EditText txtValorNF;
        EditText txtPesoNF;
        EditText txtVolume;
        Button btnEnviar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Activity_SimularFrete);

            FindViews();
            SetStyle();
            btnEnviar.Click += BtnEnviar_Click;
            txtOrigem.Click += TxtOrigem_Click;
            txtDestino.Click += TxtDestino_Click;

        }

        private void TxtOrigem_Click(object sender, System.EventArgs e)
        {

            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_BuscarCidade dialog = new Dialog_BuscarCidade();
            dialog.DialogClosed += Dialog_DialogClosedOrigem;
            dialog.Show(transaction, "dialog");
            
        }

        private void Dialog_DialogClosedOrigem(object sender, Helpers.DialogEventArgs e)
        {
            txtOrigem.Text = e.ReturnValue;
        }

        private void TxtDestino_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_BuscarCidade dialog = new Dialog_BuscarCidade();
            dialog.DialogClosed += Dialog_DialogClosedDestino;
            dialog.Show(transaction, "dialog");
        }

        private void Dialog_DialogClosedDestino(object sender, Helpers.DialogEventArgs e)
        {
            txtDestino.Text = e.ReturnValue;
        }

        private void BtnEnviar_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "Testando", ToastLength.Short).Show();
        }

        private void FindViews()
        {
            txtOrigem = FindViewById<EditText>(Resource.Id.txtOrigem);
            txtDestino = FindViewById<EditText>(Resource.Id.txtDestino);
            txtValorNF = FindViewById<EditText>(Resource.Id.txtValorNF);
            txtPesoNF = FindViewById<EditText>(Resource.Id.txtPesoNF);
            txtVolume = FindViewById<EditText>(Resource.Id.txtVolume);
            btnEnviar = FindViewById<Button>(Resource.Id.btnEnviar);
        }

        private void SetStyle()
        {
            txtOrigem.SetBackgroundResource(Resource.Drawable.BordaBotoes);
            txtDestino.SetBackgroundResource(Resource.Drawable.BordaBotoes);
            txtValorNF.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            txtPesoNF.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            txtVolume.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            btnEnviar.SetBackgroundResource(Resource.Drawable.BordaBotoes);
        }
    }
}