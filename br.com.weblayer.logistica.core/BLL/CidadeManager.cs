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
    public class CidadeManager
    {
        public List<Cidade> GetCidade(/*string filtro*/)
        {
            var lista = new List<Cidade>();

            
            lista.Add(new Cidade { ds_cidade = "Diadema", ds_estado = "SP", ds_codmun = "3513801" });
            lista.Add(new Cidade { ds_cidade = "Sorocaba", ds_estado = "SP", ds_codmun = "3552205" });
            lista.Add(new Cidade { ds_cidade = "Osasco", ds_estado = "SP", ds_codmun = "3534401" });
            lista.Add(new Cidade { ds_cidade = "Barueri", ds_estado = "SP", ds_codmun = "3505708" });
            lista.Add(new Cidade { ds_cidade = "S�o Paulo", ds_estado = "SP", ds_codmun = "3550308" });
            lista.Add(new Cidade { ds_cidade = "Rio de Janeiro", ds_estado = "RJ", ds_codmun = "3304557" });

            return lista;

        }
    }
}