using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Preferences;
using br.com.weblayer.logistica.core;
using br.com.weblayer.logistica.core.BLL;

namespace br.com.weblayer.logistica.android
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
		public static string MyPREFERENCES = "MyPrefs";
		EditText edtServidor, edtUsuario, edtSenha;
		TextView lblmensagem;
		Button btnEntrar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Login);

			edtServidor = FindViewById<EditText>(Resource.Id.edtServidor);
			edtUsuario = FindViewById<EditText>(Resource.Id.edtUsuario);
			edtSenha  = FindViewById<EditText>(Resource.Id.edtSenha);
			btnEntrar = FindViewById<Button>(Resource.Id.btnEntrar);
			lblmensagem = FindViewById<TextView>(Resource.Id.txtMensagem);

			RestoreForm();

			btnEntrar.Click += (object sender, EventArgs e) =>
			{
				SaveForm();

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

		private void RestoreForm()
		{ 

			var prefs = Application.Context.GetSharedPreferences(MyPREFERENCES, FileCreationMode.WorldReadable);
			var somePref = prefs.GetString("Login", "");
			edtUsuario.Text = somePref;

			somePref = prefs.GetString("Senha", "");
			edtSenha.Text = somePref;

			somePref = prefs.GetString("Servidor", "");
			edtServidor.Text = somePref;


		}

		private void SaveForm()
		{ 
		
			var prefs = Application.Context.GetSharedPreferences(MyPREFERENCES, FileCreationMode.WorldWriteable);
			var prefEditor = prefs.Edit();
			prefEditor.PutString("Login", edtUsuario.Text);
			prefEditor.PutString("Senha", edtSenha.Text);
			prefEditor.PutString("Servidor", edtServidor.Text);

			prefEditor.Commit();
		
		}

    }
}

