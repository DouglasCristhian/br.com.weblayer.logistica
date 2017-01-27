using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Views;
using br.com.weblayer.logistica.core.BLL;
using System.Collections.Generic;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(MainLauncher = false)]
    public class Activity_Menu : Activity
    {
        Android.Support.V7.Widget.Toolbar toolbar;
        private List<string> lstItensMenu;
        private ListView ListView_Menu;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Activity_Menu);

            FindViews();
            BindData();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_toolbar, menu);
            return true;
        }

        private void FindViews()
        {
            ListView_Menu = FindViewById<ListView>(Resource.Id.ListView_Menu);

            //if (UsuarioManager.Instance.usuario.ds_perfil=="TRANSPORTADOR")
            //    btnSimularFrete.Visibility = ViewStates.Gone;
            
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = " W/Embarcador";
            toolbar.SetLogo(Resource.Mipmap.ic_menu);
            toolbar.InflateMenu(Resource.Menu.menu_toolbar);       
        }

        private void ListView_Menu_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (e.Id == 0)
            {
                StartActivity(typeof(Activity_BuscaNotaView));
            }

            if (e.Id == 1)
            {
                StartActivity(typeof(Activity_Performance));
            }

            if (e.Id == 2)
            {
                StartActivity(typeof(Activity_CenarioEntrega));
            }

            if (e.Id == 3)
            {
                StartActivity(typeof(Activity_SimularFrete));
            }
        }

        private void BindData()
        {
          lstItensMenu = GetData();

          ListView_Menu.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, lstItensMenu);

          ListView_Menu.ItemClick += ListView_Menu_ItemClick;
          toolbar.MenuItemClick += Toolbar_MenuItemClick;
        }

        private void Toolbar_MenuItemClick(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.action_sobre:
                    StartActivity(typeof(Activity_Sobre));
                    break;

                case Resource.Id.action_ajuda:
                    StartActivity(typeof(Activity_Ajuda));
                    break;
            }
        }

        private string GetVersion()
        {
            return Application.Context.PackageManager.GetPackageInfo(Application.Context.ApplicationContext.PackageName, 0).VersionName;
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

        private List<string> GetData()
        {
            //Teste da condição
            //UsuarioManager.Instance.usuario.ds_perfil = "TRANSPORTADOR";

            List<string> lista = new List<string>();
            lista.Add("Informar Entrega");
            lista.Add("Performance do Transportador");
            lista.Add("Cenário de Entrega");

            if (UsuarioManager.Instance.usuario.ds_perfil != "TRANSPORTADOR")
            {
                lista.Add("Simular Frete");
            }

            return lista;
        }
    }
}
