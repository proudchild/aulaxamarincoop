using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Multiplataforma.Views
{
    public class MinhaPaginaSemXAML : ContentPage
    {
        public MinhaPaginaSemXAML()
        {
            this.Title = "Meu Título";
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
            this.ToolbarItems.Add(new ToolbarItem("Add", "icon.png", new Action (() => {
                
            })));
        }
    }
}