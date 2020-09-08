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
    public partial class ContactDetail : ContentPage
    {
        public ContactDetail(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException();
            InitializeComponent();
            BindingContext = contact;
        }
    }
}