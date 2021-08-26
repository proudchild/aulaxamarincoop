using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Multiplataforma.Views
{
    public class TabbedPageSemCodigo : TabbedPage
    {
        public TabbedPageSemCodigo()
        {
            Children.Add(new MinhaNovaPagina());
        }
    }
}