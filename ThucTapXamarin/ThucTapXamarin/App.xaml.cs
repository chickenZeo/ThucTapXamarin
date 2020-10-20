using System;
using ThucTapXamarin.Excercise.Exercise_2.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThucTapXamarin
{
    public partial class App : Application
    {
        //private const string TitleKey = "Title";
        //private const string NotificationsEnabledKey = "NotificationsEnabled";
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StudentsPage());
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

        //public string Title
        //{
        //    get
        //    {
        //        if (Current.Properties.ContainsKey(TitleKey))
        //            return (string)Current.Properties[TitleKey];
        //        return "";
        //    }
        //    set
        //    {
        //        Properties[TitleKey] = value;
        //    }
                
        //}

        //public bool NotificationsEnabled 
        //{
        //    get
        //    {
        //        if (Current.Properties.ContainsKey(NotificationsEnabledKey))
        //            return (bool)Current.Properties[NotificationsEnabledKey];
        //        return false;
        //    }
        //    set
        //    {
        //        Properties[NotificationsEnabledKey] = value;    
        //    }
        //}
    }
}
