using MinhaTelaDeLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Multiplataforma.Views
{
    public class MinhaContentPageCodeOnly : ContentPage
    {
        LoginView myLogin = new LoginView();
        
        private StackLayout myStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" },
                    new Label { Text = "Welcome to Xamarin.Forms!" },
                    
                }
        };
        public MinhaContentPageCodeOnly()
        {
            myStack.Children.Add(myLogin);
            Content = this.myStack;
            myLogin.Login += () =>
            {
                //Escrevo meu fluxo de login pro salesforce
                //facebook
            };
        }

        public void pegaVermelho()
        {
            var redLabel = myStack
                            .Children
                            .Where(x => x.BackgroundColor == Color.Red)
                            .Select(x => x)
                            .ToList();
        }
    }
}