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

namespace br.com.weblayer.logistica.android
{
    public class NotaFiscalListAdapter : BaseAdapter<NotaFiscal>
    {
        public List<NotaFiscal> mItems;
        public Context mContext;

        public NotaFiscalListAdapter(Context context, List<NotaFiscal> items)
        {
            mItems = items;
            mContext = context;
        }

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override NotaFiscal this[int position]
        {
            get
            {
                return mItems[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
                  row = LayoutInflater.From(mContext).Inflate(Resource.Layout.buscanotarowview, null, false);
            

            row.FindViewById<TextView>(Resource.Id.txtCliente).Text= mItems[position].ds_cliente;
            row.FindViewById<TextView>(Resource.Id.txtNumNota).Text ="Nº Nota: " + mItems[position].ds_numeronota;
            row.FindViewById<TextView>(Resource.Id.txtSerie).Text = "Série: " + mItems[position].ds_serienota;
            row.FindViewById<TextView>(Resource.Id.txtValor).Text = "Valor: R$" + mItems[position].ds_valor;

            return row;

        }

    }
}