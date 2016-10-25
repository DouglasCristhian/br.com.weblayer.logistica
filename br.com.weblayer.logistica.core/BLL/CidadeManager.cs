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
        public List<Cidade> GetCidade(string filtro)
        {

            var lista = new List<Cidade>();

            lista.Add(new Cidade { ds_cidade = "Porto Feliz", ds_estado = "SP"});
            lista.Add(new Cidade { ds_cidade = "Itu", ds_estado = "SP" });
            lista.Add(new Cidade { ds_cidade = "Sorocaba", ds_estado = "SP" });
            lista.Add(new Cidade { ds_cidade = "Osasco", ds_estado = "SP" });
            lista.Add(new Cidade { ds_cidade = "Baruri", ds_estado = "SP" });
            lista.Add(new Cidade { ds_cidade = "São Paulo", ds_estado = "SP" });
            lista.Add(new Cidade { ds_cidade = "Rio de Janeiro", ds_estado = "RJ" });

            return lista;

        }
    }
}