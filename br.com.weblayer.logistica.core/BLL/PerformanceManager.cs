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
    public class PerformanceManager
    {
        public List<Performance> GetPerformance()
        {
           

            //return lista ;
            var datainicial = GetStartOfMonth(DateTime.Now.Month, DateTime.Now.Year);
            var datafinal= GetEndOfMonth(DateTime.Now.Month, DateTime.Now.Year);


            //Acessar serviço remoto e validar usuário.
            var service = new WebService.EmbarcadorService
            {
                Url = UsuarioManager.Instance.PathWebService()
            };

            var retorno = service.RetornaPerformance(UsuarioManager.Instance.usuario.id_empresa, datainicial, datafinal, "",
                UsuarioManager.Instance.usuario.id_transportadora);

            var Performance = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Performance>>(retorno);

            return Performance;


        }

        public static DateTime GetStartOfMonth(int month, int year)
        {
            return new DateTime(year, month, 1, 0, 0, 0, 0);
        }
        public static DateTime GetEndOfMonth(int month, int year)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59, 999);
        }
    }
}