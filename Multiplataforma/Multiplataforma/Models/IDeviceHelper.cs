using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Multiplataforma.Models
{
    public interface IDeviceHelper
    {
        string GetPlatformName();
        Size GetScreenSize();
    }
}
