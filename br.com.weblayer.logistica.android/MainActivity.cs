using Android.App;
using Android.Widget;
using Android.OS;

namespace br.com.weblayer.logistica.android
{
    [Activity(Label = "br.com.weblayer.logistica.android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

		EditText edtServidor, edtUsuario, edtSenha;
		Button btnEntrar;
	


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

			edtServidor = FindViewById<EditText>(Resource.Id.edtServidor);
			edtUsuario = FindViewById<EditText>(Resource.Id.edtUsuario);
			edtSenha  = FindViewById<EditText>(Resource.Id.edtSenha);
		


		


			var usuario= UsuarioManager.ExecutarLogin("servidor", "login","senha");
			if (usuario== null)
			{
				//usuario não encontrado, login não efetuado		
				//exibir msg de erro
			}
			else
			{ 
				//login ocorreu com sucesso
				//mudar para próxima tela
			}
					


		}
    }
}

