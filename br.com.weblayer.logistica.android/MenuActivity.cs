﻿
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


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Menu);

			lblusuario = FindViewById<TextView>(Resource.Id.lblUsuario);

			lblusuario.Text = UsuarioManager.Instance.usuario.ds_empresa;


		}
	}
}
