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
    public partial class MyCarousel : CarouselPage
    {
        public MyCarousel()
        {
            InitializeComponent();
            this.Children.Add(new MinhaPaginaSemXAML());
            this.Children.Add(new MinhaNovaPagina());
            this.Children.Add(new MyNavigationPage());
        }

    }
}