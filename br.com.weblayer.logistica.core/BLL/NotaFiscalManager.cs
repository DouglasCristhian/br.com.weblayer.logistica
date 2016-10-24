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
    public class NotaFiscalManager
    {
        public string mensagem
        {
            get;
            set;
        }

        public List<NotaFiscal> GetNotaFiscal(string filtro)
        {

            var lista= new List<NotaFiscal>();

            lista.Add(new NotaFiscal { id_nota = 1, ds_cliente = "SDB COMERCIO DE ALIMENTOS LTDA", ds_destino = "BRUSQUE", ds_numeronota = "000245183", ds_serienota = "1", ds_valor = "154,35", dt_entrega = DateTime.Parse("2016/04/01") });
            lista.Add(new NotaFiscal { id_nota = 2, ds_cliente = "EMPRESA CATARINENSE DE SM LTDA", ds_destino = "BRUSQUE", ds_numeronota = "000245183", ds_serienota = "1", ds_valor = "154,35", dt_entrega = DateTime.Parse("2016/04/01") });
            lista.Add(new NotaFiscal { id_nota = 3, ds_cliente = "CEREALISTA TUCABU LTDA ME", ds_destino = "BRUSQUE", ds_numeronota = "000245183", ds_serienota = "1", ds_valor = "154,35", dt_entrega = DateTime.Parse("2016/04/01") });
            lista.Add(new NotaFiscal { id_nota = 4, ds_cliente = "N E N COMERCIO DE ALIMENTOS LT.", ds_destino = "BRUSQUE", ds_numeronota = "000245183", ds_serienota = "1", ds_valor = "154,35", dt_entrega = DateTime.Parse("2016/04/01") });
            lista.Add(new NotaFiscal { id_nota = 5, ds_cliente = "DIA BRASIL SOCIEDADE LIMITADA", ds_destino = "BRUSQUE", ds_numeronota = "000245183", ds_serienota = "1", ds_valor = "154,35", dt_entrega = DateTime.Parse("2016/05/01") });
            lista.Add(new NotaFiscal { id_nota = 6, ds_cliente = "ZENILDA REBOUCAS DE ALMEIDA M", ds_destino = "BRUSQUE", ds_numeronota = "000245183", ds_serienota = "1", ds_valor = "154,35", dt_entrega = DateTime.Parse("2016/05/01") });
            lista.Add(new NotaFiscal { id_nota = 7, ds_cliente = "COVABRA SUPERMERCADOS LTDA", ds_destino = "BRUSQUE", ds_numeronota = "000245183", ds_serienota = "1", ds_valor = "154,35", dt_entrega = DateTime.Parse("2016/05/01") });
            lista.Add(new NotaFiscal { id_nota = 8, ds_cliente = "COOP. D PLANT. DE CANA DO OES", ds_destino = "BRUSQUE", ds_numeronota = "000245183", ds_serienota = "1", ds_valor = "154,35", dt_entrega = DateTime.Parse("2016/05/01") });

            return lista;

        }

        public bool InformarEntregaNotaFiscal(int id_nota, DateTime dt_entrega)
        {

            //mandar a informação de entrega para o webservice.

            return true;

        }


    }

}