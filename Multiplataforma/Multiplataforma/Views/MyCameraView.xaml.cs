using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Multiplataforma.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCameraView : ContentPage
    {
        public event Action ShouldTakePicture = () => { };
        public MyCameraView()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ShouldTakePicture();
        }

        public void ShowImage(byte[] array)
        {
            if (array == null) return; 
            MyIMage.Source = ImageSource.FromStream(() => new MemoryStream(array));
        }
    }
}