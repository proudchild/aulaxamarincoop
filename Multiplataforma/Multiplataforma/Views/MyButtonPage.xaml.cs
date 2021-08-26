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
    public partial class MyButtonPage : ContentPage
    {

        

        List<Button> buttons = new List<Button>();
        public MyButtonPage()
        {
            InitializeComponent();
            StackLayout meuStack = (StackLayout)this.Content;
            buttons.Add((Button)meuStack.FindByName("Button1"));
            Button BotaoDoCodigo = new Button()
            {
                Text = "Botão do Código",
                BackgroundColor = Color.FromHex("#FFFFFF")
            };
            meuStack.Children.Add(BotaoDoCodigo);
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.FromHex("#AB9522");
            Button meuBotao = (Button)sender;
            if(meuBotao.Id == buttons[0].Id)
            {
                meuBotao.BackgroundColor = Color.FromHex("#22AB22");
                Navigation.PushAsync(new MyLabelPage());
            }
            if(((Button)Content.FindByName("Button2")).Id == ((Button)sender).Id)
            {
                Navigation.PushAsync(new MyInputPage());
            }

            //Login?.Invoke(this, LoginEvent)
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {

        }
    }
}