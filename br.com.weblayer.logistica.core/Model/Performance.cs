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

namespace br.com.weblayer.logistica.core.Model
{

    public class Performance
    {
        public virtual int id_periodo
        { get; set; }

        public virtual string ds_visao
        { get; set; }

        public virtual string ds_titulo
        { get; set; }

        public virtual string ds_cor
        { get; set; }

        public virtual string ds_percentual_performance_minima
        { get; set; }

        public virtual string ds_percentual_performance
        { get; set; }

        public virtual string ds_percentual_notas_entregues
        { get; set; }

        public virtual string ds_numero_notas_total
        { get; set; }

        public virtual string ds_dias_media_atraso
        { get; set; }

    }

}