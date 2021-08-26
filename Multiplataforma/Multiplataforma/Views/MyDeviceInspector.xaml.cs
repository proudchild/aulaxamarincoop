using Multiplataforma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Multiplataforma.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyDeviceInspector : ContentPage
    {
        public MyDeviceInspector()
        {
            InitializeComponent();
            IDeviceHelper deviceHelper = DependencyService.Get<IDeviceHelper>();
            Size tamaho = deviceHelper.GetScreenSize();
            string ptname = deviceHelper.GetPlatformName();

            PlatformName.Text = ptname;
            DeviceSize.Text = "Width: " + tamaho.Width.ToString() + " Height: " + tamaho.Height.ToString();


        }
    }
}