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
    public class CenarioEntrega
    {
        public virtual int nr_dias
        { get; set; }

        public virtual int nr_notas
        { get; set; }

    }
}