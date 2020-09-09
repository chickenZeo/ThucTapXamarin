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
        private SearchService _searchService;
        public ObservableCollection<SearchGroup> SearchGroups { get; set; }
        public List_Exercise()
        {
            _searchService = new SearchService();
            InitializeComponent();
            listView.ItemsSource = GetData();
        }
        private IEnumerable<SearchGroup> GetData()
        {
            SearchGroups = new ObservableCollection<SearchGroup>{
                new SearchGroup("Recent searches", (ObservableCollection<Search>)_searchService.GetSearches()),
            };
            return SearchGroups;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchResults = new ObservableCollection<SearchGroup>();
            
            foreach(var item in SearchGroups)
            {
                var getResults = _searchService.GetSearches(e.NewTextValue);
                searchResults.Add(new SearchGroup(item.Title, new ObservableCollection<Search>(getResults)));
            }
            listView.ItemsSource = searchResults;
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = SearchGroups;
            listView.EndRefresh();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var deleteSearch = (sender as MenuItem).CommandParameter as Search;
            var listTmp = new ObservableCollection<SearchGroup>();
            foreach (var item in SearchGroups)
            {
                var delete = _searchService.DeleteSearch(deleteSearch.Id, item);
                listTmp.Add(new SearchGroup (item.Title, new ObservableCollection<Search>(delete)));
            }
            listView.ItemsSource = listTmp;
        }
    }
}

