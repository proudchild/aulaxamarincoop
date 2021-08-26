using Multiplataforma.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Lead meuLead = new Lead();

        public string FirstName { get; set; }

        public ObservableCollection<LeadStatus> listaLeadStatus;

        public Message thisMessage = new Message() { message = "Mudando o controle de versão" };


        public LeadCreateView()
        {

            InitializeComponent();
            FirstName = "Vitor";
            meuLead.LastName = " Nishida";

            BindingContext = meuLead;

            listaLeadStatus = new ObservableCollection<LeadStatus>()
            {
                new LeadStatus(){ApiName = "New", Label = "Novo"},
                new LeadStatus(){ApiName = "Qualification", Label = "Qualificação"},
                new LeadStatus(){ApiName = "Disqualified", Label = "Desqualificado"},
                new LeadStatus(){ApiName = "Converted", Label = "Convertido"},
            };

            EntryStatusPicker.BindingContext = listaLeadStatus;

            OutroBinding.BindingContext = thisMessage;

        }

        private void SaveLead_Clicked(object sender, EventArgs e)
        {
            EntryFirstName.TextColor = Color.Blue;
            LabelMensagem.BindingContext = thisMessage;
            meuLead.Save();
        }
    }
}