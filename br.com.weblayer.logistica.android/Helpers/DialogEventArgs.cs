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

namespace br.com.weblayer.logistica.android.Helpers
{
    public class DialogEventArgs
    {
        //you can put other properties here that may be relevant to check from activity
        //for example: if a cancel button was clicked, other text values, etc.
        public string ReturnValue { get; set; }
    }
}