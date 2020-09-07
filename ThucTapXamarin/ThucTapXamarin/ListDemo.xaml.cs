using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTapXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThucTapXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListDemo : ContentPage
    {
        private ObservableCollection<Contact> _contacts;

        public IEnumerable<Contact> GetContacts(string searchText = null)
        {
            _contacts = new ObservableCollection<Contact> {
                new Contact { Name = "John", ImageUrl = "img1.jpg" },
                new Contact { Name = "Tommy", ImageUrl = "ing2.jpg", Status = "Hello World" }
            };
            if (String.IsNullOrWhiteSpace(searchText))
                return _contacts;
            return _contacts.Where(x => x.Name.StartsWith(searchText));
        }
        public ListDemo()
        {
            InitializeComponent();

            listView.ItemsSource = GetContacts();
        }

        //private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var contact = e.Item as Contact;
        //    DisplayAlert("Tapped", contact.Name, "OK");
        //}

        //private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    listView.SelectedItem = null;
        //}


        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var contact = menuItem.CommandParameter as Contact;
            DisplayAlert("Call", contact.Name, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            DisplayAlert("Call", contact.Name, "OK");
            _contacts.Remove(contact);
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = GetContacts();
            listView.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetContacts(e.NewTextValue);
        }
    }
}