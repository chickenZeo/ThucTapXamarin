
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
    public partial class ActivitiesPage : ContentPage
    {
        private ActivityService _activityService = new ActivityService();
        public ActivitiesPage()
        {
            InitializeComponent();
            listView.ItemsSource = _activityService.GetActivities();
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var activity = e.SelectedItem as Activity;
            listView.SelectedItem = null;
            await Navigation.PushAsync(new UserProfile(activity.UserId));
        }
    }
}