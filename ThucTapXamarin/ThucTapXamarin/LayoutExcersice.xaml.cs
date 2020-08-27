using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThucTapXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LayoutExcersice : ContentPage
    {
        public LayoutExcersice()
        {
            InitializeComponent();
        }

        void OnBtnLoginClicked(object sender, EventArgs e)
        {
            DisplayAlert("Login", "Login successfull", "OK");
        }
        void OnBtnRegisterClicked(object sender, EventArgs e)
        {
            DisplayAlert("Register", "Register successfull", "OK");
        }
    }
}