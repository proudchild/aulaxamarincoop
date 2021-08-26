using Foundation;
using Multiplataforma.iOS.Helpers;
using Multiplataforma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceHelper))]
namespace Multiplataforma.iOS.Helpers
{
    class DeviceHelper : IDeviceHelper
    {
        public string GetPlatformName()
        {
            return "IOS";
        }

        public Size GetScreenSize()
        {
            var width = UIScreen.MainScreen.Bounds.Width;
            var height = UIScreen.MainScreen.Bounds.Height;
            return new Size(width, height);
        }
    }
}