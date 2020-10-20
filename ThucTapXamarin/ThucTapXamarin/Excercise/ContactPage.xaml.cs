using ThucTapXamarin.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ThucTapXamarin.Presistence;
using SQLite;

namespace ThucTapXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        private ObservableCollection<Contact> _listContacts;
        private SQLiteAsyncConnection _connection;
        private bool _isLoadedData;
        public ContactPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }
        protected override async void OnAppearing()
        {
            if (_isLoadedData)
                return;
            _isLoadedData = true;

            await LoadData();
            base.OnAppearing();
        }
        private async Task LoadData()
        {
            await _connection.CreateTableAsync<Contact>();
            var contacts = await _connection.Table<Contact>().ToListAsync();
            _listContacts = new ObservableCollection<Contact>(contacts);
            listViewContacts.ItemsSource = _listContacts;
        }
        private async void OnAddBtn_Clicked(object sender, EventArgs e)
        {
            var page = new ContactDetailPage(new Contact());
            page.AddedContact += (source, contact) =>
            {
                _listContacts.Add(contact);
            };

            await Navigation.PushAsync(page);
        }

        
        private async void OnDeleteBtn_Clicked(object sender, EventArgs e)
        {
            var deleteContact = (sender as MenuItem).CommandParameter as Contact;
            var answer = await DisplayAlert("Warning", "Do you want to delete" + deleteContact.FullName, "Yes", "No");

            if (answer)
            {
                _listContacts.Remove(deleteContact);
                await _connection.DeleteAsync(deleteContact);
            }
        }

        private async void listViewContacts_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            if (listViewContacts.SelectedItem == null)
                return;
            var selectedContact = e.SelectedItem as Contact;
            var page = new ContactDetailPage(selectedContact);
            listViewContacts.SelectedItem = null;
            page.UpdatedContact += (source, contact) =>
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