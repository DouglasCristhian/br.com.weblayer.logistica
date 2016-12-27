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
    public class Resultado
    {
        public virtual string ds_resultado //OK ou //ERRO
        { get; set; }

        public virtual string ds_observacao
        { get; set; }

    }
}