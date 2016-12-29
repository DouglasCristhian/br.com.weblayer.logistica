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
    public class Cidade
    {
        public virtual string ds_cidade
        { get; set; }

        public virtual string ds_estado
        { get; set; }

        public virtual string ds_codmun
        { get; set; }

    }
}