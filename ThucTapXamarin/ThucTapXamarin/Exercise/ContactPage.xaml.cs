using System;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ThucTapXamarin.Models;
using System.Collections.ObjectModel;

namespace ThucTapXamarin.Exercise
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class ContactPage : ContentPage
    {
        private ObservableCollection<Contact> _listContacts;
        private Contact _c = new Contact();
        public ContactPage()
        {
            InitializeComponent();
            _listContacts = new ObservableCollection<Contact>();
            _listContacts = _c.GetContacts();
            listview.ItemsSource = _listContacts;
        }

        private async void OnAddBtn_Clicked(object sender, EventArgs e)
        {
            var page = new ContactDetailPage(new Contact());
            page.ContactAdded += (source, contact) =>
            {
                _listContacts.Add(contact);
            };
            await Navigation.PushAsync(page);
        }

        private async void OnDeleteBtn_Clicked(object sender, EventArgs e)
        {
            var delete = (sender as MenuItem).CommandParameter as Contact;
            var answer = await DisplayAlert("Are you sure?", null, "Yes", "No");
            if (answer)
                _listContacts.Remove(delete);
        }

        private async void Onlistview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listview.SelectedItem == null)
                return;
            var selectedContact = e.SelectedItem as Contact;
            listview.SelectedItem = null;

            var page = new ContactDetailPage(selectedContact);
            page.ContactUpdated += (source, contact) =>
            {
                selectedContact.Id = contact.Id;    
                selectedContact.FirstName = contact.FirstName;    
                selectedContact.LastName = contact.LastName;    
                selectedContact.Phone = contact.Phone;    
                selectedContact.Email = contact.Email;    
                selectedContact.IsBlocked = contact.IsBlocked;    
            };

            await Navigation.PushAsync(page);
        }
    }
}