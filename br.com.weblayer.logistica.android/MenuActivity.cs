
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
	[Activity]
	public class MenuActivity : Activity
	{

        TextView lblusuario;

        private Button btnInformarEntrega;
        private Button btnPerformance;
        private Button btnSimularFrete;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Menu);

            FindViews();

            lblusuario = FindViewById<TextView>(Resource.Id.lblMenuUsuario);

			lblusuario.Text = UsuarioManager.Instance.usuario.ds_empresa;

            btnInformarEntrega.Click += BtnInformarEntrega_Click;    

        }

        private void BtnInformarEntrega_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(BuscaNotaViewActivity));
        }

        private void FindViews()
        {

            btnInformarEntrega = FindViewById<Button>(Resource.Id.btnMenuInformaEntrega);
            btnPerformance = FindViewById<Button>(Resource.Id.btnMenuPerformanceEntrega);
            btnSimularFrete = FindViewById<Button>(Resource.Id.btnMenuSimularFrete);
        }


    }
}
