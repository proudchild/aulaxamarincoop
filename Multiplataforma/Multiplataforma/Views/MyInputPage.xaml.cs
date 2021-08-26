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
    public partial class MyInputPage : ContentPage
    {
        public string ParrotName { get; set; }
        public string ParrotHistory { get; set; }

        public int MyValue = 24;
        public MyInputPage()
        {
            InitializeComponent();
        }

        private void PapagaioName_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ParrotName = e.NewTextValue;
        }

        private void PapagioHistory_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ParrotHistory = e.NewTextValue;
        }

        private void EvaluateHistory_Clicked(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(this.ParrotHistory)) return;
            if (this.ParrotHistory.ToLower().Contains("morreu"))
            {
                ((Label)this.Content.FindByName("Avaliation")).Text = "Puuuts morreu o bichinho....";

            }
            else
            {
                Avaliation.Text = "Que linda história";
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(e.NewTextValue)) return;
            if(PapagaioHistory.Text.Contains(e.NewTextValue))
            Avaliation.Text = "O conteúdo está no texto";
            else Avaliation.Text = "O conteúdo não está no texto";
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            PapagaioHistory.IsEnabled = e.Value;
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            PapagaioSearch.IsVisible = e.Value;
        }

        private void PapagaioSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Avaliation.FontSize = e.NewValue;
            SliderSize.Text = e.NewValue.ToString();
            PapagaioProgress.ProgressTo(e.NewValue / PapagaioSlider.Maximum - PapagaioSlider.Minimum,5,Easing.BounceIn);
        }

        private void PapagaioName_Completed(object sender, EventArgs e)
        {

        }
    }
}