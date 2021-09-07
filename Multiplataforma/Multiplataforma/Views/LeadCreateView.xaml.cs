using Multiplataforma.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.WebRequestMethods;

namespace Multiplataforma.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeadCreateView : ContentPage
    {
        public Lead meuLead = new Lead();

        public string FirstName { get; set; }

        public ObservableCollection<LeadStatus> listaLeadStatus;

        public Message thisMessage = new Message() { message = "Lead Salvo com sucesso" };


        public LeadCreateView()
        {

            InitializeComponent();
            FirstName = "TesteS";
            meuLead.LastName = " TesteS";
            //Teste
            //Teste
            BindingContext = meuLead;


            /*listaLeadStatus = new ObservableCollection<LeadStatus>()
            {
                new LeadStatus(){ApiName = "New", Label = "Novo"},
                new LeadStatus(){ApiName = "Qualification", Label = "Qualificação"},
                new LeadStatus(){ApiName = "Disqualified", Label = "Desqualificado"},
                new LeadStatus(){ApiName = "Converted", Label = "Convertido"},
            };*/

            GetLeadPicklist();

            OutroBinding.BindingContext = thisMessage;

        }

        private async void GetLeadPicklist()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri(string.Format("https://copacol--devcopacol.my.salesforce.com/services/data/v53.0/sobjects/Lead/describe", string.Empty));
            /*
             Para conseguir um token execute o seguinte no anonymous do developer console:
            Lead l = [SELECT Id, Description FROM Lead Limit 1];
            l.Description = UserInfo.getSessionId();
            update l;
            System.debug(LoggingLevel.ERROR,l.Id);

            abra o lead que ele salvou e cole ali do lado bearer
             
             */
            client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", "");
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                JObject leadDescribe = JObject.Parse(content) as JObject;
                listaLeadStatus = new ObservableCollection<LeadStatus>();
                foreach (JObject field in leadDescribe["fields"])
                {
                    if(field["name"].ToString() == "Status")
                    {
                        JArray array = field["picklistValues"] as JArray;
                        foreach(JObject jvalue in array)
                        {
                            if ((bool)jvalue["active"])
                            {
                                LeadStatus status = new LeadStatus()
                                {
                                    ApiName = jvalue["value"].ToString(),
                                    Label = jvalue["label"].ToString()
                                };
                                listaLeadStatus.Add(status);
                            }
                        }

                    }
                }
                EntryStatusPicker.BindingContext = listaLeadStatus;
                EntryStatusPicker.ItemsSource = listaLeadStatus;
            }
        }

        private void SaveLead_Clicked(object sender, EventArgs e)
        {
            EntryFirstName.TextColor = Color.Blue;
            LabelMensagem.BindingContext = thisMessage;
            meuLead.Save();
        }

        private void MeuConflito()
        {

        }
    }
}