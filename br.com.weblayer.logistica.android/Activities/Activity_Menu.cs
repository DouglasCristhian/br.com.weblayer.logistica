using System;
using Android.App;
using Android.OS;
using Android.Widget;

using br.com.weblayer.logistica.core.BLL;

namespace br.com.weblayer.logistica.android.Activities
{
	[Activity]
	public class Activity_Menu : Activity
	{

        TextView lblusuario;

        private Button btnInformarEntrega;
        private Button btnPerformance;
        private Button btnSimularFrete;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Activity_Menu);

            FindViews();

            lblusuario = FindViewById<TextView>(Resource.Id.lblMenuUsuario);

			lblusuario.Text = UsuarioManager.Instance.usuario.ds_empresa;

            btnInformarEntrega.Click += BtnInformarEntrega_Click;    

        }

        private void BtnInformarEntrega_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(Activity_BuscaNotaView));
        }

        private void FindViews()
        {

            btnInformarEntrega = FindViewById<Button>(Resource.Id.btnMenuInformaEntrega);
            btnPerformance = FindViewById<Button>(Resource.Id.btnMenuPerformanceEntrega);
            btnSimularFrete = FindViewById<Button>(Resource.Id.btnMenuSimularFrete);
        }


    }
}
