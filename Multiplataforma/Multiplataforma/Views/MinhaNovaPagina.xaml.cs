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
    public partial class MinhaNovaPagina : ContentPage
    {
        public MinhaNovaPagina()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}