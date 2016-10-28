using System;
using Android.App;
using Android.OS;
using Android.Widget;

using br.com.weblayer.logistica.core.BLL;

namespace br.com.weblayer.logistica.android.Activities
{
	[Activity(MainLauncher = false)]
	public class Activity_Menu : Activity_Base
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
            BindData();

			lblusuario.Text = UsuarioManager.Instance.usuario.ds_empresa;
        }

        private void BtnInformarEntrega_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(Activity_BuscaNotaView));
        }

        private void BtnPerformance_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Activity_Performance));
        }

        private void BtnSimularFrete_Click(object sender, EventArgs e)
        {
           StartActivity(typeof(Activity_SimularFrete));
        }

        private void FindViews()
        {
            lblusuario = FindViewById<TextView>(Resource.Id.lblMenuUsuario);
            btnInformarEntrega = FindViewById<Button>(Resource.Id.btnMenuInformaEntrega);
            btnPerformance = FindViewById<Button>(Resource.Id.btnMenuPerformanceEntrega);
            btnSimularFrete = FindViewById<Button>(Resource.Id.btnMenuSimularFrete);
        }

        private void BindData()
        {
            btnInformarEntrega.Click += BtnInformarEntrega_Click;
            btnPerformance.Click += BtnPerformance_Click;
            btnSimularFrete.Click += BtnSimularFrete_Click;
        }
    }
}
