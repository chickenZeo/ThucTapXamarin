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
        public ObservableCollection<SearchGroup> SearchGroups { get; set; }
        public List_Exercise()
        {
            InitializeComponent();
            listView.ItemsSource = GetData();
        }
        private IEnumerable<SearchGroup> GetData()
        {
            var searches = new ObservableCollection<Search>
            {
                new Search(1,"Ha Noi,Viet Nam",DateTime.Parse("2020/06/05"),DateTime.Parse("2020/06/08")),
                new Search(3,"Ho Chi Minh,Viet Nam",DateTime.Parse("2020/04/20"),DateTime.Parse("2020/04/25")),
                new Search(2,"West Kollywood,CA,United States",DateTime.Parse("2020/02/05"),DateTime.Parse("2020/02/08"))
            };
            SearchGroups = new ObservableCollection<SearchGroup>{
                new SearchGroup("Recent searches", searches),
            };
            return SearchGroups;
        }

        // Search by Loaction
        private IEnumerable<SearchGroup> GetSearches(string filler = null)
        {
            if (String.IsNullOrEmpty(filler))
                return SearchGroups;
            else
            {
                var results = new ObservableCollection<SearchGroup>();
                foreach (var item in SearchGroups)
                {
                    var searchResult = item.Where(x => x.Location.ToLower().Contains(filler.ToLower()));
                    results.Add(new SearchGroup(item.Title, new ObservableCollection<Search>(searchResult)));
                }
                return results;
            }
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetSearches(e.NewTextValue);
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = SearchGroups;
            listView.EndRefresh();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var deleteSearch = (sender as MenuItem).CommandParameter as Search;
            foreach (var item in SearchGroups)
                item.Remove(deleteSearch);
        }
    }
}

