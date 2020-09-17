using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ThucTapXamarin
{
    public partial class MainPage : CarouselPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            //var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "No");
            //if (response)
            //   await DisplayAlert("Done", "Your response will be saved!", "OK");

            var response = await DisplayActionSheet("Title", "Cancel", "Delete", "Coppy link", "Email", "Message");
            await DisplayAlert("Response", response, "OK");
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Toolbar clicked", "You clicked toolbar", "OK");
        }
    }
}
