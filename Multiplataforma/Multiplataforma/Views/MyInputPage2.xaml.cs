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
    public partial class MyInputPage2 : ContentPage
    {

        private DateTime minhaData;
        public MyInputPage2()
        {
            InitializeComponent();
            SizePicker.Items.Add("50");
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Unicorn.HeightRequest = Convert.ToDouble(SizePicker.SelectedItem);
        }

        private void MinhaData_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }

        private void MinhaData_DateSelected(object sender, DateChangedEventArgs e)
        {
            minhaData = e.NewDate;
            MeuTimer.Time = new TimeSpan(10, 15, 25);
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            MyIndicator.IsRunning = false;
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            MyIndicator.IsRunning = true;
        }
    }
}