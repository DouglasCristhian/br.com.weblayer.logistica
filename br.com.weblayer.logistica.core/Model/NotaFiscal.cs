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
using Java.IO;

namespace br.com.weblayer.logistica.core.Model
{
    public class NotaFiscal  
    {

        public NotaFiscal()
        {
        }

        public int id_nota
        { get; set; }

        public string ds_numeronota
        { get; set; }

        public string ds_serienota
        { get; set; }

        public string ds_cliente
        { get; set; }

        public string ds_valor
        { get; set; }

        public   DateTime? dt_entrega
        { get; set; }

        public string ds_destino
        { get; set; }

       


    }
}