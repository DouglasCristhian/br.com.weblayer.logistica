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
    public class NotaFiscal
    {

        public virtual int id_nota
        { get; set; }

        public virtual string ds_numeronota
        { get; set; }

        public virtual string ds_serienota
        { get; set; }

        public virtual string ds_cliente
        { get; set; }

        public virtual string ds_valor
        { get; set; }

        public virtual DateTime? dt_entrega
        { get; set; }

        public virtual string ds_destino
        { get; set; }

    }
}