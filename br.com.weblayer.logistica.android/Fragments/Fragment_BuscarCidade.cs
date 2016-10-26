using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using br.com.weblayer.logistica.android.Helpers;
using br.com.weblayer.logistica.core.Model;
using System.Collections.Generic;
using br.com.weblayer.logistica.android.Adapters;
using br.com.weblayer.logistica.core.BLL;
using Android.Support.V4;
using Android.OS;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Dialog_BuscarCidade")]
    public class Dialog_BuscarCidade : DialogFragment
    {
        public event EventHandler<DialogEventArgs> DialogClosed;
        ListView ListViewCidades;
        List<Cidade> ListaCidades;
        string Retorno;
        EditText txtInformarCidade;
        Button btnPesquisarCidade;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Fragment_BuscarCidade, container, false);

            btnPesquisarCidade = (Button)view.FindViewById(Resource.Id.btnPesquisarCidade);
            txtInformarCidade = (EditText)view.FindViewById(Resource.Id.txtInformarCidade);
            ListViewCidades = (ListView)view.FindViewById(Resource.Id.CidadeListView);

            SetStyle();

            Retorno = "";

            btnPesquisarCidade.Click += BtnPesquisarCidade_Click;

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var ListViewCidadeClick = sender as ListView;
            var lista = ListaCidades[e.Position];
        }

        private void BtnPesquisarCidade_Click(object sender, EventArgs e)
        {
            FillList();
            //Dismiss();
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);
            if (DialogClosed != null)
            {
                DialogClosed(this, new DialogEventArgs { ReturnValue = Retorno });
            }

        }

        private void SetStyle()
        {
            txtInformarCidade.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            btnPesquisarCidade.SetBackgroundResource(Resource.Drawable.BordaBotoes);
        }
    

        private void FillList()
        {
           ListaCidades = new CidadeManager().GetCidade();
           ListViewCidades.Adapter = new Adapter_Cidade_ListView(this.Activity, ListaCidades);
           
        }
    }
  
}