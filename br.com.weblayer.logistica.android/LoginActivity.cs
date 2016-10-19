using System;
using Android.App;
using Android.Widget;
using Android.OS;
using br.com.weblayer.logistica.core;

namespace br.com.weblayer.logistica.android
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {

		EditText edtServidor, edtUsuario, edtSenha;
		TextView lblmensagem;
		Button btnEntrar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Login);

			edtServidor = FindViewById<EditText>(Resource.Id.edtServidor);
			edtUsuario = FindViewById<EditText>(Resource.Id.edtUsuario);
			edtSenha  = FindViewById<EditText>(Resource.Id.edtSenha);
			btnEntrar = FindViewById<Button>(Resource.Id.btnEntrar);
			lblmensagem = FindViewById<TextView>(Resource.Id.txtMensagem);

			btnEntrar.Click += (object sender, EventArgs e) =>
			{
				ExecutarLogin();
			};
		}

		private void ExecutarLogin()
		{ 
			var usuariomanager = UsuarioManager.Instance;

			lblmensagem.Text= "";

			var retorno = usuariomanager.ExecutarLogin(edtServidor.Text, edtUsuario.Text, edtSenha.Text);
			if (!retorno)
			{
				lblmensagem.Text=usuariomanager.mensagem;
			}
			else
			{
				StartActivity(typeof(MenuActivity));
			}
		}

    }
}

