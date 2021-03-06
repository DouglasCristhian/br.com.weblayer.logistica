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

namespace br.com.weblayer.logistica.android.Adapters
{
    public class Adapter_Cidade_ListView : BaseAdapter<Cidade>
    {
        public List<Cidade> mItems;
        public Context mContext;

        public Adapter_Cidade_ListView(Context context, List<Cidade> items)
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

        public override Cidade this[int position]
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
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.Adapter_Cidade_ListView, null, false);

            row.FindViewById<TextView>(Resource.Id.txtCidade).Text = mItems[position].ds_cidade;
            row.FindViewById<TextView>(Resource.Id.txtEstado).Text = mItems[position].ds_estado;

            return row;

        }
    }
}