using br.com.weblayer.logistica.core.Model;
using System.Collections.Generic;

namespace br.com.weblayer.logistica.core.BLL
{
    public class CenarioEntregaManager
    {
        //    public List<CenarioEntrega> GetCenario(/*string filtro*/)
        //    {
        //        var lista = new List<CenarioEntrega>();

        //        lista.Add(new CenarioEntrega { nr_dias = -6, nr_notas = 5});
        //        lista.Add(new CenarioEntrega { nr_dias = -4, nr_notas = 10 });
        //        lista.Add(new CenarioEntrega { nr_dias = -2, nr_notas = 15 });
        //        lista.Add(new CenarioEntrega { nr_dias = 0, nr_notas = 30 });
        //        lista.Add(new CenarioEntrega { nr_dias = 3, nr_notas = 25 });
        //        lista.Add(new CenarioEntrega { nr_dias = 7, nr_notas = 14 });
        //        lista.Add(new CenarioEntrega { nr_dias = 20, nr_notas = 9 });
        //        lista.Add(new CenarioEntrega { nr_dias = 30, nr_notas = 3 });

        //        return lista;

        //    }

        public List<CenarioEntrega> GetCenario2(int ano, int mes)
        {
            var lista = new List<CenarioEntrega>();

            lista.Add(new CenarioEntrega { nr_dias = -14, nr_notas = 1 });
            lista.Add(new CenarioEntrega { nr_dias = -13, nr_notas = 1 });
            lista.Add(new CenarioEntrega { nr_dias = -12, nr_notas = 1 });
            lista.Add(new CenarioEntrega { nr_dias = -10, nr_notas = 3 });
            lista.Add(new CenarioEntrega { nr_dias = -9, nr_notas = 2 });
            lista.Add(new CenarioEntrega { nr_dias = -8, nr_notas = 1 });
            lista.Add(new CenarioEntrega { nr_dias = -7, nr_notas = 1 });
            lista.Add(new CenarioEntrega { nr_dias = -6, nr_notas = 2 });
            lista.Add(new CenarioEntrega { nr_dias = -5, nr_notas = 1 });
            lista.Add(new CenarioEntrega { nr_dias = -4, nr_notas = 2 });
            lista.Add(new CenarioEntrega { nr_dias = -3, nr_notas = 7 });
            lista.Add(new CenarioEntrega { nr_dias = -2, nr_notas = 2 });
            lista.Add(new CenarioEntrega { nr_dias = -1, nr_notas = 11 });
            lista.Add(new CenarioEntrega { nr_dias = -0, nr_notas = 225 });
            lista.Add(new CenarioEntrega { nr_dias = 1, nr_notas = 43 });
            lista.Add(new CenarioEntrega { nr_dias = 2, nr_notas = 35 });
            lista.Add(new CenarioEntrega { nr_dias = 3, nr_notas = 31 });
            lista.Add(new CenarioEntrega { nr_dias = 4, nr_notas = 16 });
            lista.Add(new CenarioEntrega { nr_dias = 5, nr_notas = 23 });
            lista.Add(new CenarioEntrega { nr_dias = 6, nr_notas = 8 });
            lista.Add(new CenarioEntrega { nr_dias = 7, nr_notas = 2 });
            lista.Add(new CenarioEntrega { nr_dias = 8, nr_notas = 2 });
            lista.Add(new CenarioEntrega { nr_dias = 11, nr_notas = 1 });

            return lista;

        }
    }
}