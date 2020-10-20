
using Xamarin.Forms;

namespace ThucTapXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = Application.Current;
            //if (Application.Current.Properties.ContainsKey("Title"))
            //    title.Text = (string)Application.Current.Properties["Title"];
            //if (Application.Current.Properties.ContainsKey("NotificationsEnabled"))
            //    notificationsEnabled.On = (bool)Application.Current.Properties["NotificationsEnabled"];
           
        }
        //private void OnChanged(object sender, EventArgs e)
        //{
        //    Application.Current.Properties["Title"] = title.Text;
        //    Application.Current.Properties["NotificationsEnabled"] = notificationsEnabled.On;
        //}
    }
}
