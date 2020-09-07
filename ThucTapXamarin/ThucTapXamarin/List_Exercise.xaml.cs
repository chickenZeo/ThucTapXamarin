using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTapXamarin.Service;
using ThucTapXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace ThucTapXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class List_Exercise : ContentPage
    {
        public ObservableCollection<SearchGroup> Searches { get; set; }
        public ObservableCollection<Search> LSearches { get; set; }
        public List_Exercise()
        {
            InitializeComponent();
            listView.ItemsSource = GetData();
        }
        private IEnumerable<SearchGroup> GetData()
        {
            LSearches = new ObservableCollection<Search>
            {
                new Search(1,"Ha Noi,Viet Nam",DateTime.Parse("2020/06/05"),DateTime.Parse("2020/06/08")),
                new Search(3,"Ho Chi Minh,Viet Nam",DateTime.Parse("2020/04/20"),DateTime.Parse("2020/04/25")),
                new Search(2,"West Hollywood,CA,United States",DateTime.Parse("2020/02/05"),DateTime.Parse("2020/02/08"))
            };
            Searches = new ObservableCollection<SearchGroup>{
                new SearchGroup("Recent searches", LSearches)
            };
            return Searches;
        }
       
        // Search by Loaction
        private IEnumerable<Search> GetSearches(string filler = null) {
            if (String.IsNullOrEmpty(filler))
                return LSearches;
            return LSearches.Where(x => x.Location.StartsWith(filler));
        } 
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
           listView.ItemsSource = GetSearches(e.NewTextValue);
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = Searches;
            listView.EndRefresh();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            

        }

    }


}

