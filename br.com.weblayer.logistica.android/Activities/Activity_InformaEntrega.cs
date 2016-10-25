using System;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

using br.com.weblayer.logistica.core.Model;
using DatePickerHelper = br.com.weblayer.logistica.android.Helpers.DatePickerHelper;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Informar Entrega")]
    public class Activity_InformaEntrega : Activity
    {
        private TextView txtNomeCliente;
        private TextView txtValor;
        private TextView txtNota;
        private TextView txtSerie;
        private TextView txtData;
        private TextView lblMensagem;
        private Button btnConfirmarEntrega;

        private Cidade nota;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Activity_InformaEntrega);

            //string da nota
            var jsonnota = Intent.GetStringExtra("JsonNota");

            //transforma a string no objeto
            nota = Newtonsoft.Json.JsonConvert.DeserializeObject<Cidade>(jsonnota);

            FindViews();
            BindData();
            txtData.Click += EventtxtData_Click;
            btnConfirmarEntrega.Click += BtnConfirmarEntrega_Click;

        }

        private void FindViews()
        {
            txtNomeCliente = FindViewById<TextView>(Resource.Id.txtNomeCliente);
            txtValor = FindViewById<TextView>(Resource.Id.txtValorNota);
            txtNota = FindViewById<TextView>(Resource.Id.txtNota);
            txtSerie = FindViewById<TextView>(Resource.Id.txtSerie);
            txtData = FindViewById<TextView>(Resource.Id.txtDataEntrega);
            lblMensagem = FindViewById<TextView>(Resource.Id.lblMensagem);

            btnConfirmarEntrega = FindViewById<Button>(Resource.Id.btnConfirmarEntrega);
        }

        private void BindData()
        {
            txtNomeCliente.Text = nota.ds_cliente;
            txtValor.Text = nota.ds_valor;
            txtNota.Text = nota.ds_numeronota + "/" + nota.ds_serienota;
            lblMensagem.Text = "";

            btnConfirmarEntrega.Visibility = ViewStates.Visible;

            if (nota.dt_entrega.HasValue)
            {
                txtData.Text = nota.dt_entrega.Value.ToString("dd/MM/yyyy"); //Caso a nota j� tenha sido entegue, mostrar a data de entrega.
                                                                             // btnConfirmarEntrega.Enabled = false; //TODO: deixar o bot�o invis�vel
                btnConfirmarEntrega.Visibility = ViewStates.Invisible;

            }
            else
                txtData.Text = DateTime.Now.ToString("dd/MM/yyyy"); //Caso contr�rio sugerir a data de hoje.

        }

        private void SetStyles()
        {
            txtData.SetBackgroundResource(Resource.Drawable.BordaBotoes);
            btnConfirmarEntrega.SetBackgroundResource(Resource.Drawable.BordaBotoes);

        }
        private void EnviaDadosEntrega()
        {
            try
            {

                var dataentrega = DateTime.Parse(txtData.Text);

                var notamanager = new core.BLL.NotaFiscalManager();

                var retorno = notamanager.InformarEntregaNotaFiscal(nota.id_nota, dataentrega);
                if (retorno)
                {
                    //volto para a tela que chamou passando sucesso!
                    Intent myIntent = new Intent(this, typeof(Activity_InformaEntrega));
                    myIntent.PutExtra("mensagem", notamanager.mensagem);
                    SetResult(Result.Ok, myIntent);
                    Finish();
                }
                else
                {
                    //Permancecer nessa tela e exibir a mensagem do erro
                    lblMensagem.Text = notamanager.mensagem;
                }


            }
            catch (Exception ex)
            {
                //exibir a mensagem do erro
                lblMensagem.Text = ex.Message;
            }

        }

        private void EventtxtData_Click(object sender, EventArgs e)
        {
            //Call Fragment
            DatePickerHelper frag = DatePickerHelper.NewInstance(delegate (DateTime time)
            {
                txtData.Text = time.ToShortDateString();
            });

            frag.Show(FragmentManager, DatePickerHelper.TAG);
        }
        
        private void BtnConfirmarEntrega_Click(object sender, EventArgs e)
        {

            var progressDialog = ProgressDialog.Show(this, "Por favor aguarde...", "Enviando os dados...", true);
            new Thread(new ThreadStart(delegate
            {
                Thread.Sleep(1000);

                //LOAD METHOD TO GET ACCOUNT INFO
                RunOnUiThread(() => EnviaDadosEntrega());

                //HIDE PROGRESS DIALOG
                RunOnUiThread(() => progressDialog.Hide());
            })).Start();
           
        }

    }
}