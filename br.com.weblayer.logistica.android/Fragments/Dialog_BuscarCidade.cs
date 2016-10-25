using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using br.com.weblayer.logistica.android.Helpers;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Dialog_BuscarCidade")]
    public class Dialog_BuscarCidade : DialogFragment
    {

        public event EventHandler<DialogEventArgs> DialogClosed;

        string Retorno;
        Button btn1;
        Button btn2;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.Dialog_BuscarCidade, container, false);

            btn1 = (Button)view.FindViewById(Resource.Id.btn1);
            btn2 = (Button)view.FindViewById(Resource.Id.btn2);

            Retorno = "";

            btn1.Click += Btn1_Click;

            return view;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text == null)
                return;

            Retorno = btn1.Text;

            Dismiss();

        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);
            if (DialogClosed != null)
            {
                DialogClosed(this, new DialogEventArgs { ReturnValue = Retorno });
            }

        }
    }

   
}