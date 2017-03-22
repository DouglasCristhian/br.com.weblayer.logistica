using Android.App;
using Android.OS;
using Android.Views;
using br.com.weblayer.logistica.core.BLL;
using br.com.weblayer.logistica.core.Model;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;
using System.Collections.Generic;
using System.Linq;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class Activity_CenarioEntrega : Activity_Base
    {
        private PlotView view;
        Android.Support.V7.Widget.Toolbar toolbar;

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
            this.Title = "Cenário de Entrega";
            toolbar.InflateMenu(Resource.Menu.menu_toolbar);
            toolbar.Menu.RemoveItem(Resource.Id.action_sobre);
            toolbar.Menu.RemoveItem(Resource.Id.action_sair);

            FindViews();
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

        private void FindViews()
        {
            view = FindViewById<PlotView>(Resource.Id.plotView);
            view.Model = GraficoColunas();
        }

        private PlotModel GraficoColunas()
        {
            var plotModel = new PlotModel()
            {
                LegendPlacement = LegendPlacement.Outside,
                IsLegendVisible = true,

            };

            plotModel.Title = "Cenário de Entrega";

            CenarioEntrega ent = new CenarioEntrega();
            CenarioEntregaManager manager = new CenarioEntregaManager();
            List<CenarioEntrega> list = manager.GetCenario2();

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
                //LabelPlacement = LabelPlacement.Inside,         

            };

            for (int i = 0; i < SortedList.Count; i++)
            {
                if (SortedList[i].nr_dias < 0)
                {
                    categoryAxis1.Labels.Add((SortedList[i].nr_dias * -1).ToString() + " dias");
                    columnSeries.Items.Add(new ColumnItem(SortedList[i].nr_notas) { Color = OxyColors.Red });
                    //columnSeries.
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
    }
}