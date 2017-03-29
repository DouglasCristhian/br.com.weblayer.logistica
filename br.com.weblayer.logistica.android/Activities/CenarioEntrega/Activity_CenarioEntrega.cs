using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using br.com.weblayer.logistica.core.BLL;
using br.com.weblayer.logistica.core.Model;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;
using System;
using System.Collections.Generic;
using System.Linq;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class Activity_CenarioEntrega : Activity_Base
    {
        Android.Support.V7.Widget.Toolbar toolbar;
        private PlotView view;
        private string AnoSelecionado;
        private int MesSelecionado;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.Activity_CenarioEntrega;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.menu_toolbar);
            toolbar.Menu.RemoveItem(Resource.Id.action_sobre);
            toolbar.Menu.RemoveItem(Resource.Id.action_sair);

            Filtro_Spinner();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_toolbar, menu);
            menu.RemoveItem(Resource.Id.action_sobre);
            menu.RemoveItem(Resource.Id.action_ajuda);
            menu.RemoveItem(Resource.Id.action_sair);
            return true;
        }

        private void Filtro_Spinner()
        {
            var prefs = Application.Context.GetSharedPreferences("MyPrefs", FileCreationMode.WorldWriteable);
            var prefEditor = prefs.Edit();

            string ano = prefs.GetString("PrefAnoCenarioEntregaString", DateTime.Now.Year.ToString());
            AnoSelecionado = ano;

            int mes = prefs.GetInt("PrefMesCenarioEntrega", DateTime.Now.Month);

            if (mes == 0)
            {
                mes = DateTime.Now.Month;
            }

            MesSelecionado = mes;

            FindViews();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                case Resource.Id.action_filtrar:

                    Intent intent = new Intent();
                    intent.SetClass(this, typeof(Activity_FiltrarCenarioEntrega));
                    StartActivityForResult(intent, 0);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FindViews()
        {
            view = FindViewById<PlotView>(Resource.Id.plotView);

            string DataFinal = (MesSelecionado + "/" + AnoSelecionado).ToString();
            this.Title = "Cenário de Entrega (" + DataFinal + ")";

            BindData();
        }

        private void BindData()
        {
            view.Model = GraficoColunas(int.Parse(AnoSelecionado), MesSelecionado);
        }

        private PlotModel GraficoColunas(int ano, int mes)
        {
            var plotModel = new PlotModel()
            {
                LegendPlacement = LegendPlacement.Outside,
                IsLegendVisible = true,

            };

            plotModel.Title = "Cenário de Entrega";

            CenarioEntrega ent = new CenarioEntrega();
            CenarioEntregaManager manager = new CenarioEntregaManager();
            List<CenarioEntrega> list = manager.GetCenario2(ano, mes);

            List<CenarioEntrega> SortedList = list.OrderBy(o => o.nr_dias).ToList();

            var categoryAxis1 = new CategoryAxis()
            {
                Title = "Período da Entrega",

                MaximumRange = 15,
            };

            var columnSeries = new ColumnSeries()
            {
                FontSize = 15,
                TextColor = OxyColors.Black,
                ColumnWidth = 20,

            };

            for (int i = 0; i < SortedList.Count; i++)
            {
                if (SortedList[i].nr_dias < 0)
                {
                    categoryAxis1.Labels.Add((SortedList[i].nr_dias * -1).ToString() + " dias");
                    columnSeries.Items.Add(new ColumnItem(SortedList[i].nr_notas) { Color = OxyColors.Red });
                }
            }

            var columnSeries2 = new ColumnSeries()
            {
                FontSize = 25,
                TextColor = OxyColors.Black,
                LabelPlacement = LabelPlacement.Outside,
            };

            for (int i = 0; i < SortedList.Count; i++)
            {
                if (SortedList[i].nr_dias >= 0)
                {
                    categoryAxis1.Labels.Add(SortedList[i].nr_dias.ToString() + " dias");
                    columnSeries.Items.Add(new ColumnItem(SortedList[i].nr_notas) { Color = OxyColors.Green });
                }
            }

            plotModel.Axes.Add(categoryAxis1);
            plotModel.Series.Add(columnSeries);
            plotModel.Series.Add(columnSeries2);

            return plotModel;
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            AnoSelecionado = data.GetStringExtra("AnoCenarioEntregaString");
            MesSelecionado = data.GetIntExtra("MesCenarioEntregaPosicao", DateTime.Now.Month);

            if (AnoSelecionado == null || MesSelecionado.ToString() == null)
            {
                Filtro_Spinner();
            }
            else
            {
                if (MesSelecionado == 0)
                {
                    MesSelecionado = DateTime.Now.Month;
                }

                FindViews();
                //GraficoColunas(int.Parse(AnoSelecionado), MesSelecionado);
            }

        }
    }
}