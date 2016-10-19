using System.Collections.Generic;

namespace br.com.weblayer.logistica.core.BLL
{
	public class UsuarioManager
	{

		public string mensagem
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

				var usuario = Usuarios[0];

				if (usuario.id_empresa == 0)
				{
					mensagem = usuario.ds_perfil;
					return false;
				}

				//gravar dados sobre o usuário

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