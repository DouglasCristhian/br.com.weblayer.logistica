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
using br.com.weblayer.logistica.core.Model;

namespace br.com.weblayer.logistica.core.BLL
{
    public class NotaFiscalManager
    {
        public string mensagem
        {
            get; 
            set;
        }

        public List<NotaFiscal> GetNotaFiscal(string filtro)
        {

            try
            {
                //Acessar serviço remoto e validar usuário.
                var service = new WebService.EmbarcadorService
                {
                    Url = UsuarioManager.Instance.usuario.ds_servidor
                };

                var retorno = service.BuscarNota(UsuarioManager.Instance.usuario.id_empresa, UsuarioManager.Instance.usuario.id_transportadora, filtro);

                var Notas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NotaFiscal>>(retorno);

                return Notas;

            }
            catch (System.Exception ex)
            {
                mensagem = ex.Message;
                return null;
            }

        }

        public bool InformarEntregaNotaFiscal(int id_nota, DateTime dt_entrega)
        {

            var service = new WebService.EmbarcadorService
            {
                Url = UsuarioManager.Instance.usuario.ds_servidor
            };

            var retorno = service.InformarEntrega(UsuarioManager.Instance.usuario.id_empresa, id_nota, dt_entrega, UsuarioManager.Instance.usuario.id_usuario,"Android","-","-","-");

            var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Resultado>>(retorno);

            mensagem = resultado[0].ds_observacao;

            if (resultado[0].ds_resultado=="OK")
                return true;
            else
                return false;




        }


    }

}