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
    public partial class MeuNavegador : ContentPage
    {
        private List<String> addressStack = new List<String>();
        private List<String> forwardStack = new List<String>();
        private string url = "";
        public MeuNavegador()
        {
            InitializeComponent();
        }

        private void go_Clicked(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(address.Text))
            {
                navigate();

            }
        }

        private void navigate()
        {
            if (!String.IsNullOrEmpty(url))
            {
                addressStack.Add(url);
            }
            forwardStack.Clear();
            url = "";
            if (address.Text.Contains("."))
            {
                if (!address.Text.Contains("https://")) url += "https://";
                url += address.Text;
            }
            else
            {
                url = "https://www.google.com/search?q=" + address.Text;
            }
            if(addressStack.Count() > 0)
            {
                back.IsVisible = true;
            }
            else
            {
                back.IsVisible = false;
            }
            if(forwardStack.Count() > 0)
            {
                forward.IsVisible = true;
            }
            else
            {
                forward.IsVisible = false;
            }
            pagina.Source = url;
        }

        private void address_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void back_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(url))
            {
                forwardStack.Add(url);
            }
            url = addressStack.Last();
            pagina.Source = url;
            addressStack.RemoveAt(addressStack.Count - 1);
            if(addressStack.Count == 0)
            {
                back.IsVisible = false;
            }
            else
            {
                back.IsVisible = true;
            }
            address.Text = url;
        }

        private void forward_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(url))
            {
                addressStack.Add(url);
            }
            url = forwardStack.Last();
            pagina.Source = url;
            forwardStack.RemoveAt(forwardStack.Count - 1);
            if (addressStack.Count == 0)
            {
                back.IsVisible = false;
            }
            else
            {
                back.IsVisible = true;
            }
            address.Text = url;
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            loading.IsRunning = false;
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            loading.IsRunning = true;
        }

        private void reload_Clicked(object sender, EventArgs e)
        {
            pagina.Reload();
        }
    }
}