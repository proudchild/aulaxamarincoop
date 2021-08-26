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
    public partial class MyAlertView : ContentPage
    {
        public MyAlertView()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Titulo", "Mensagem", "Botão");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            var result = await  DisplayAlert("Titulo", "Sim ou Não","Sim","Não");
            if (result)
            {
                DisplayAlert("Titulo", "Apertou sim", "Botão");

            }
            else
            {

                DisplayAlert("Titulo", "Apertou não", "Botão");
            }
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet("Escolha um numero", "Cancel", null, "5", "10", "20", "40", "60");
            DisplayAlert("Titulo", result, "Botão");
        }
    }
}