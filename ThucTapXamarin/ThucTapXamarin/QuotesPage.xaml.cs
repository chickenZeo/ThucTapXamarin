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
    public partial class QuotesPage : ContentPage
    {
        private string[] _quotes = {
            "Life is like riding a bicycle. To keep your balance, you must keep moving.",
            "You can't blame gravity for falling in love.",
            "Look deep into nature, and then you will understand everything better."};
        private int _count = 0;
        public QuotesPage()
        {
            InitializeComponent();
            // display quotes
            content.Text = _quotes[_count];
        }

        void OnNextBtnClicked(object sender, EventArgs e)
        {
            _count++;
            if (_count > _quotes.Length - 1)
                _count = 0;
            content.Text = _quotes[_count];

        }
    }
}