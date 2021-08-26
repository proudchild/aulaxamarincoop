using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Multiplataforma.Droid.Helper;
using Multiplataforma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceHelper))]
namespace Multiplataforma.Droid.Helper
{
    class DeviceHelper : IDeviceHelper
    {
        public string GetPlatformName()
        {
            return "Android";
        }

        public Size GetScreenSize()
        {
            var displayMetrics = Resources.System.DisplayMetrics;
            var width = displayMetrics.WidthPixels / displayMetrics.Density;
            var height = displayMetrics.HeightPixels / displayMetrics.Density;
            return new Size(width, height);
        }
    }
}