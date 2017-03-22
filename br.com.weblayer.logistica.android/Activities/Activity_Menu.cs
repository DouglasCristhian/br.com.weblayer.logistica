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
            toolbar.Title = "W/Embarcador";
            toolbar.InflateMenu(Resource.Menu.menu_toolbar);       
        }

        private void ListView_Menu_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            
            if (GetData()[(int)e.Id] == "Performance do Transportador" || GetData()[(int)e.Id] == "Minha Performance")
            {
                StartActivity(typeof(Activity_Performance)); 
            }

            if (GetData()[(int)e.Id] == "Informar Entrega")
            {
                StartActivity(typeof(Activity_BuscaNotaView));
            }

            
            if (GetData()[(int)e.Id] == "Cenário de Entrega")
            {
                StartActivity(typeof(Activity_CenarioEntrega));
            }

            if (GetData()[(int)e.Id] == "Simular Frete")
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

                case Resource.Id.action_sair:
                    Finish();
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

            List<string> lista = new List<string>();

            if (UsuarioManager.Instance.usuario.ds_perfil == "ADMIN")
            {
                lista.Add("Performance do Transportador");
                lista.Add("Informar Entrega");
                lista.Add("Cenário de Entrega");
                lista.Add("Simular Frete");
            }

            if (UsuarioManager.Instance.usuario.ds_perfil == "TRANSPORTADOR")
            {
                lista.Add("Minha Performance");
                lista.Add("Informar Entrega");
            }

            return lista;
        }
    }
}
