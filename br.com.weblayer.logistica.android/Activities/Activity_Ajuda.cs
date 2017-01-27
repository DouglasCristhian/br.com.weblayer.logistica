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
using Android.Support.V4.View;
using br.com.weblayer.logistica.android.exp.Fragments;

namespace br.com.weblayer.logistica.android.Activities
{
    [Activity(Label = "Activity_Ajuda")]
    public class Activity_Ajuda : Activity_Base
    {
        Android.Support.V7.Widget.Toolbar toolbar;
        ViewPager pager;
        GenericFragmentPagerAdaptor adapter;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.Activity_Ajuda;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Ajuda";

            pager = FindViewById<ViewPager>(Resource.Id.pager);
            adapter = new GenericFragmentPagerAdaptor(SupportFragmentManager);

            adapter.AddFragmentView((i, v, b) =>
            {
                var view = i.Inflate(Resource.Layout.Fragment_UtilizandoApp, v, false);
                return view;
            });

            pager.Adapter = adapter;
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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_toolbar, menu);
            menu.RemoveItem(Resource.Id.action_ajuda);
            menu.RemoveItem(Resource.Id.action_sobre);

            return base.OnCreateOptionsMenu(menu);
        }

    }
}