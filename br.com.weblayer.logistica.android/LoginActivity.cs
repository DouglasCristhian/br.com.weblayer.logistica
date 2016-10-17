﻿using System;
using Android.App;
using Android.Widget;
using Android.OS;

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
			var usuariomanager = new UsuarioManager();

			lblmensagem.Text= "";

			var usuario = usuariomanager.ExecutarLogin("servidor", "login", "senha");
			if (usuario == null)
			{
				lblmensagem.Text=usuariomanager.mensagem;

				//usuario não encontrado, login não efetuado		
				//exibir msg de erro
				//usuariomanager.mensagem
			}
			else
			{
				//login ocorreu com sucesso
				//mudar para próxima tela
				StartActivity(typeof(MenuActivity));

			}
		}

    }
}

