using Multiplataforma.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Multiplataforma.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyListViewPage : ContentPage
    {
        List<Lead> Leads; 

        public MyListViewPage()
        {
            
            InitializeComponent();
            this.Leads = new List<Lead>();
            Lead l1 = new Lead() { FirstName = "Sergio", LastName="Migueis"};
            Leads.Add(l1);
            Lead l2 = new Lead() { FirstName = "Maycon", LastName = "Schipitoski" };
            Leads.Add(l2);
            Lead l3 = new Lead() { FirstName = "Osni", LastName = "Oliveira" };
            Leads.Add(l3);
            Lead l4 = new Lead() { FirstName = "Nildo", LastName = "Germano" };
            Leads.Add(l4);
            Lead l5 = new Lead() { FirstName = "Vitor", LastName = "Nishida" };
            Leads.Add(l5);
            Lead l6 = new Lead() { FirstName = "Alan", LastName = "Cesar" };
            Leads.Add(l6);

            MyListView.ItemsSource = Leads.GroupBy(x => x.LastName[0]).ToList();
            MyListView.Footer = Leads;
            MyListView.Header = Leads;

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Lead l = (Lead)MyListView.SelectedItem;
            DisplayAlert("Lead Selecionado", "Você selecionou " + l.FirstName + " lead", "OK");
        }

        private async void MyListView_Refreshing(object sender, EventArgs e)
        {
            await DisplayAlert("Sincronizando", "Carregando os leads", "OK");
            MyListView.EndRefresh();
        }

        private void MySearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            MyListView.ItemsSource = Leads.Where(x => x.FirstName.Contains(e.NewTextValue) || x.LastName.Contains(e.NewTextValue)).OrderBy(x => x.FirstName).GroupBy(x => x.FirstName[0]).ToList();
        }
    }
}
