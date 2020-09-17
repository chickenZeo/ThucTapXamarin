using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ThucTapXamarin.Models;

namespace ThucTapXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : MasterDetailPage
    {
        public ContactPage()
        {
            InitializeComponent();

            List<Contact> listContacts = new List<Contact>{
                new Contact{Name = "Hevan", ImageUrl = "https://lorempixel.com/50/50/people/1"},
                new Contact{Name = "John", ImageUrl = "https://lorempixel.com/50/50/people/2", Status = "Are you ok?"},
            };
            listView.ItemsSource = listContacts;
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Contact;
            Detail = new NavigationPage(new ContactDetail(contact));
            IsPresented = false;
        }
    }
}