public class UsuarioManager
{ 

	public string mensagem
	{
		get;
		set;
	}


	public Usuario ExecutarLogin(string servidor, string login, string senha)
	{

		//Acessar serviço remoto e validar usuário.

		//Login ok
		/*
		var usuario = new Usuario();
		usuario.login = login;
		usuario.senha = senha;
		usuario.nome = "Nome retornado do banco de dados";
		mensagem = "login realizado com sucesso!";
		return usuario;
		*/

		//Login erro 
		mensagem = "Usuário/Senha inválidos!";
		return null;

	}

}
