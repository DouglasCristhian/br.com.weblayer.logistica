using System;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using br.com.weblayer.logistica.core.BLL;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon")]
    public class Activity_Login : Activity_Base
    {
		public static string MyPREFERENCES = "MyPrefs";

        EditText edtServidor, edtUsuario, edtSenha;
		TextView lblmensagem;
		Button btnEntrar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Activity_Login);

            FindViews();

            RestoreForm();

            btnEntrar.Click += BtnEntrar_Click;
		}

        private void FindViews()
        {
            edtServidor = FindViewById<EditText>(Resource.Id.edtServidor);
            edtUsuario = FindViewById<EditText>(Resource.Id.edtUsuario);
            edtSenha = FindViewById<EditText>(Resource.Id.edtSenha);
            btnEntrar = FindViewById<Button>(Resource.Id.btnEntrar);
            lblmensagem = FindViewById<TextView>(Resource.Id.txtMensagem);
        }

        private bool ValidateViews()
        {
            var validacao = true;
            if (edtServidor.Length() == 0)
            {
                validacao = false;
                edtServidor.Error = "Endereço do servidor inválido!";
            }

            if (edtUsuario.Length() == 0)
            {
                validacao = false;
                edtUsuario.Error = "Usuário inválido!";
            }

            if (edtSenha.Length() == 0)
            {
                validacao = false;
                edtSenha.Error = "Senha inválida!";
            }
            
            return validacao;

        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {

            SaveForm();

            if (!ValidateViews())
                return;

            var progressDialog = ProgressDialog.Show(this, "Por favor aguarde...", "Verificando os dados...", true);
            new Thread(new ThreadStart(delegate
            {
                System.Threading.Thread.Sleep(1000);

                //LOAD METHOD TO GET ACCOUNT INFO
                RunOnUiThread(() => ExecutarLogin());
                
                //HIDE PROGRESS DIALOG
                RunOnUiThread(() => progressDialog.Hide());
            })).Start();

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
				StartActivity(typeof(Activity_Menu));
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

