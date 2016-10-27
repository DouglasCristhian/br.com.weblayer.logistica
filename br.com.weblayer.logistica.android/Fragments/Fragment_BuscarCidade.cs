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
        SearchView svInformarCidade;
        Button btnPesquisarCidade;
        private ArrayAdapter _adapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Fragment_BuscarCidade, container, false); 

            btnPesquisarCidade = (Button)view.FindViewById(Resource.Id.btnPesquisarCidade);
            svInformarCidade = (SearchView)view.FindViewById(Resource.Id.svInformarCidade);
            ListViewCidades = (ListView)view.FindViewById(Resource.Id.CidadeListView);

            _adapter = new ArrayAdapter(Activity, Resource.Layout.Fragment_BuscarCidade, ListaCidades);
            svInformarCidade.QueryTextChange += SvInformarCidade_QueryTextChange;

            ListViewCidades.Adapter = _adapter;
            BindData();
            SetStyle();

            Retorno = "";

            btnPesquisarCidade.Click += BtnPesquisarCidade_Click;

            return view;
        }

        private void SvInformarCidade_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            _adapter.Filter.InvokeFilter(e.NewText);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var ListViewCidades = sender as ListView;
            var t = ListaCidades[e.Position];
            var cidadeestado = t.ds_cidade + "  " + t.ds_estado;

            Retorno = cidadeestado;

            Dismiss();
        }

        private void BtnPesquisarCidade_Click(object sender, EventArgs e)
        {
            FillList();
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
            svInformarCidade.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            btnPesquisarCidade.SetBackgroundResource(Resource.Drawable.BordaBotoes);
        }
    
        private void BindData()
        {
            ListViewCidades.ItemClick += OnListItemClick;
        }

        private void FillList()
        {
           ListaCidades = new CidadeManager().GetCidade();
           ListViewCidades.Adapter = new Adapter_Cidade_ListView(this.Activity, ListaCidades);
           
        }
    }
 
}