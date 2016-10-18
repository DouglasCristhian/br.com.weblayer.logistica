﻿using System.Collections.Generic;

namespace br.com.weblayer.logistica.core
{
	public class UsuarioManager
	{
		private static UsuarioManager instance;

		private UsuarioManager() { }

		public static UsuarioManager Instance
		{
			get
			{
				if (instance == null)
					lock (typeof(UsuarioManager))
						if (instance == null) instance = new UsuarioManager();

				return instance;
			}
		}

		public string mensagem
		{
			get;
			set;
		}
		public Usuario usuario
		{
			get;
			set; 
		}

		public bool ExecutarLogin(string servidor, string login, string senha)
		{

			try
			{
				//Acessar serviço remoto e validar usuário.
				WebService.Performance service = new WebService.Performance();
				service.Url = servidor;
				string retorno = service.Login(login, senha);

				List<Usuario> Usuarios= Newtonsoft.Json.JsonConvert.DeserializeObject<List<Usuario>>(retorno);

				usuario = Usuarios[0];

				if (usuario.id_empresa == 0)
				{
					mensagem = usuario.ds_perfil;
					return false;
				}

				return true;

			}
			catch (System.Exception ex)
			{
				mensagem = ex.Message;
				return false;
			}

		}

	}
}