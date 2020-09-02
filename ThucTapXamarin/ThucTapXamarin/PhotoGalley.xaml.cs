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
    public partial class PhotoGalley : ContentPage
    {
        private int _id;
        private readonly int _maxNoImages = 10;
        public PhotoGalley()
        {
            InitializeComponent();
            _id = 1;
            LoadImages();
        }

        private void LoadImages()
        {
            var imageSource = new UriImageSource
            {
                Uri = new Uri(String.Format("https://lorempixel.com/1920/1080/city/{0}/", _id))
            };
            imageSource.CachingEnabled = false;
            images.Source = imageSource;
        }

        private void OnBtnNextClicked(object sender, EventArgs e)
        {
            _id++;
            if (_id > _maxNoImages)
                _id = 1;
            LoadImages();
        }
        private void OnBtnBackClicked(object sender, EventArgs e)
        {
            _id--;
            if (_id < 1)
                _id = _maxNoImages;
            LoadImages();
        }
    }
}