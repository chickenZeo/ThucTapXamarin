using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace ThucTapXamarin
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Greeter : ContentPage
    {
        public Greeter()
        {
            InitializeComponent();

            //if(Device.RuntimePlatform == Device.Android)
            //{
            //    Padding = new Thickness(10, 20, 0, 0);
            //}
                
        }

    }
}