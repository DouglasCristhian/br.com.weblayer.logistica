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

            var lista = new List<Performance>();

            lista.Add(new Performance { id_periodo= 1, ds_titulo= "Transportadora1", ds_cor="VERDE", ds_percentual_performance="98%"});
            lista.Add(new Performance { id_periodo = 1, ds_titulo = "Transportadora2", ds_cor = "AMARELO", ds_percentual_performance = "60%" });
            lista.Add(new Performance { id_periodo = 1, ds_titulo = "Transportadora3", ds_cor = "VERMELHO", ds_percentual_performance = "20%" });

            return lista ;

        }
    }
}