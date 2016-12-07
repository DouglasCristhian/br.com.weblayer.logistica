using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Simula��o do Frete", MainLauncher = false)]
    public class Activity_SimularFrete : Activity_Base
    {
        Android.Support.V7.Widget.Toolbar toolbar;
        EditText txtOrigem;
        EditText txtDestino;
        EditText txtValorNF;
        EditText txtPesoNF;
        EditText txtVolume;
        Button btnEnviar;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.Activity_SimularFrete;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FindViews();
            SetStyle();
            btnEnviar.Click += BtnEnviar_Click;
            txtOrigem.Click += TxtOrigem_Click;
            txtDestino.Click += TxtDestino_Click;

        }

        private void TxtOrigem_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_BuscarCidade dialog = new Dialog_BuscarCidade();
            dialog.DialogClosed += Dialog_DialogClosedOrigem;
            dialog.Show(transaction, "dialog");
        }

        private void Dialog_DialogClosedOrigem(object sender, Helpers.DialogEventArgs e)
        {
            txtOrigem.Text = e.ReturnValue;
        }

        private void TxtDestino_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_BuscarCidade dialog = new Dialog_BuscarCidade();
            dialog.DialogClosed += Dialog_DialogClosedDestino;
            dialog.Show(transaction, "dialog");
        }

        private void Dialog_DialogClosedDestino(object sender, Helpers.DialogEventArgs e)
        {
            txtDestino.Text = e.ReturnValue;
        }

        private void BtnEnviar_Click(object sender, System.EventArgs e)
        {
            if (!ValidateViews())
                return;

            StartActivity(typeof(Activity_SimulacaoFreteResultado));
        }

        private void FindViews()
        {
            txtOrigem = FindViewById<EditText>(Resource.Id.txtOrigem);
            txtDestino = FindViewById<EditText>(Resource.Id.txtDestino);
            txtValorNF = FindViewById<EditText>(Resource.Id.txtValorNF);
            txtPesoNF = FindViewById<EditText>(Resource.Id.txtPesoNF);
            txtVolume = FindViewById<EditText>(Resource.Id.txtVolume);
            btnEnviar = FindViewById<Button>(Resource.Id.btnEnviar);

            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Simular Frete";
            toolbar.InflateMenu(Resource.Menu.menu_toolbarvazia);
        }

        private void SetStyle()
        {
            txtOrigem.SetBackgroundResource(Resource.Drawable.BordaBotoes);
            txtDestino.SetBackgroundResource(Resource.Drawable.BordaBotoes);
            txtValorNF.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            txtPesoNF.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            txtVolume.SetBackgroundResource(Resource.Drawable.EditTextStyle);

        }

        private bool ValidateViews()
        {
            var validacao = true;
            if (txtOrigem.Length() == 0)
            {
                validacao = false;
                txtOrigem.Error = "Origem inv�lida!";
            }
        
            if (txtDestino.Length() == 0)
            {
                validacao = false;
                txtDestino.Error = "Destino inv�lido!";
            }

            if (txtValorNF.Length() == 0)
            {
                validacao = false;
                txtValorNF.Error = "Valor do NF inv�lido!";
            }

            if (txtPesoNF.Length() == 0)
            {
                validacao = false;
                txtPesoNF.Error = "Peso do NF inv�lido!";
            }

            if (txtVolume.Length() == 0)
            {
                validacao = false;
                txtVolume.Error = "Volume inv�lido!";
            }

            return validacao;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();

                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}