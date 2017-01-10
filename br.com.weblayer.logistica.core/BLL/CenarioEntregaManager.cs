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
    public class CenarioEntregaManager
    {
        public List<CenarioEntrega> GetCenario(/*string filtro*/)
        {
            var lista = new List<CenarioEntrega>();

            lista.Add(new CenarioEntrega { nr_dias = -6, nr_notas = 5});
            lista.Add(new CenarioEntrega { nr_dias = -4, nr_notas = 10 });
            lista.Add(new CenarioEntrega { nr_dias = -2, nr_notas = 15 });
            lista.Add(new CenarioEntrega { nr_dias = 0, nr_notas = 30 });
            lista.Add(new CenarioEntrega { nr_dias = 3, nr_notas = 25 });
            lista.Add(new CenarioEntrega { nr_dias = 7, nr_notas = 14 });
            lista.Add(new CenarioEntrega { nr_dias = 20, nr_notas = 9 });
            lista.Add(new CenarioEntrega { nr_dias = 30, nr_notas = 3 });

            return lista;

        }
    }
}