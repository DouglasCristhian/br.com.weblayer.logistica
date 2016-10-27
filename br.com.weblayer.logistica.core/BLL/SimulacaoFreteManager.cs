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
    public class SimulacaoFreteManager
    {
        public List<SimulacaoFrete> GetSimulacaoFrete(string origemcodmun, string destinocodmun, decimal valornf, decimal pesonf, decimal volumenf)
        {
            var lista = new List<SimulacaoFrete>();

            lista.Add(new SimulacaoFrete { ds_transportadora = "TRANSP 1", vl_frete = decimal.Parse("10.99"),vl_frete_imposto=decimal.Parse("12.99") });
            lista.Add(new SimulacaoFrete { ds_transportadora = "TRANSP 2", vl_frete = decimal.Parse("13.56"), vl_frete_imposto = decimal.Parse("15.99") });
            lista.Add(new SimulacaoFrete { ds_transportadora = "TRANSP 3", vl_frete = decimal.Parse("15.22"), vl_frete_imposto = decimal.Parse("17.12") });
            lista.Add(new SimulacaoFrete { ds_transportadora = "TRANSP 4", vl_frete = decimal.Parse("17.33"), vl_frete_imposto = decimal.Parse("19.99") });

            return lista;
        }

    }
}