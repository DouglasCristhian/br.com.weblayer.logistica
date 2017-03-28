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

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Novidades")]
    public class Activity_Novidades : Activity_Base
    {
        Android.Support.V7.Widget.Toolbar toolbar;
        private TextView txtNovidades;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.Activity_Novidades;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Menu.RemoveItem(Resource.Id.action_filtrar);

            FindViews();
            BindData();
        }

        private void FindViews()
        {
            txtNovidades = FindViewById<TextView>(Resource.Id.txtNovidades);
        }

        private void BindData()
        {
            txtNovidades.Text = Novidades();
        }

        private string Novidades()
        {
            string Novidades;
            Novidades = " 1.0 (23/01/2017):"
                                     + "\n\n    [Novo] Implementação do leitor de código de barras"
                                     + "\n    [Melhorias] Atualização da interface";


            return Novidades;
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