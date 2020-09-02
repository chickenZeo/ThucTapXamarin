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
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();

            //var imageSource = new UriImageSource { Uri = new Uri("https://aka.ms/campus.jpg") };
            //imageSource.CachingEnabled = false; // boi vi no se luu o cache 24h nen mot vai truong hop khong dung
            //image.Source = imageSource
            //embeddedImage
             image.Source= ImageSource.FromResource("ThucTapXamarin.Images.aaaaa.jpg");
        }
    }
}