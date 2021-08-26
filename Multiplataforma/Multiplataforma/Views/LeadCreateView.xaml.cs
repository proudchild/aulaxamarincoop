using Multiplataforma.Models;
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
    public partial class LeadCreateView : ContentPage
    {
       
        public LeadCreateView()
        {
            
            InitializeComponent();
        }

        private void SaveLead_Clicked(object sender, EventArgs e)
        {
            EntryFirstName.TextColor = Color.Blue;
        }
    }
}