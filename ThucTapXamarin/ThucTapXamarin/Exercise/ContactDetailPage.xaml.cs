using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ThucTapXamarin.Models;

namespace ThucTapXamarin.Exercise
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public EventHandler<Contact> ContactAdded;
        public EventHandler<Contact> ContactUpdated;
        public ContactDetailPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));
            InitializeComponent();

            BindingContext = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked,
                Phone = contact.Phone
            };
        }

        private async void OnSaveBtn_Clicked(object sender, EventArgs e)
        {
            var contact = BindingContext as Contact;
            if (String.IsNullOrEmpty(entryFirstName.Text) || String.IsNullOrEmpty(entryLastName.Text))
                await DisplayAlert("Erorr!", "First name or Last name is not empty!!", "OK");
            else
            {
                if (contact.Id == 0)
                {
                    contact.Id = 1;
                    ContactAdded.Invoke(this, contact);
                }
                else
                    ContactUpdated(this, contact);
            }

            await Navigation.PopAsync();
        }
    }
}