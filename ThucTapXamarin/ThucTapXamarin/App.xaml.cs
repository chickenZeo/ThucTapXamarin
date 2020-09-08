using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThucTapXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WelcomePage()) { 
                BarBackgroundColor = Color.Olive,
                BarTextColor = Color.White
            };
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
