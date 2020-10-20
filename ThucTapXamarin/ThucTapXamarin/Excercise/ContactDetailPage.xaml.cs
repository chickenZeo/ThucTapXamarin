using ThucTapXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using ThucTapXamarin.Presistence;

namespace ThucTapXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public EventHandler<Contact> AddedContact;
        public EventHandler<Contact> UpdatedContact;
        private SQLiteAsyncConnection _connection;
        public ContactDetailPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException();
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            BindingContext = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked,
            };
        }

        private async void OnSaveBtn_Clicked(object sender, EventArgs e)
        {
            var contact = BindingContext as Contact;
            if (String.IsNullOrEmpty(entryFName.Text) || String.IsNullOrEmpty(entryLName.Text))
            {
                await DisplayAlert("Warning", "Name is not allowed null", "OK");
                return;
            }
            else
            {
                if (contact.Id == 0)
                {
                    await _connection.InsertAsync(contact);
                    AddedContact?.Invoke(this, contact);
                }
                else
                {
                    await _connection.UpdateAsync(contact);
                    UpdatedContact?.Invoke(this, contact);
                }

            }
            await Navigation.PopAsync();
        }
    }
}