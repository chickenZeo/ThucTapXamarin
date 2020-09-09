using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ThucTapXamarin.Models;

namespace ThucTapXamarin.Service
{
    public class SearchService
    {
        public ObservableCollection<Search> Searches { get; set; }
        public IEnumerable<Search> GetSearches(string filler = null)
        {
            Searches = new ObservableCollection<Search> {
                new Search(1,"Ha Noi, Viet Nam",DateTime.Parse("2020/06/05"),DateTime.Parse("2020/06/08")),
                new Search(3,"Ho Chi Minh, Viet Nam",DateTime.Parse("2020/04/20"),DateTime.Parse("2020/04/25")),
                new Search(2,"West Kollywood, CA, United States",DateTime.Parse("2020/02/05"),DateTime.Parse("2020/02/08"))
            };
            if (String.IsNullOrWhiteSpace(filler))
                return Searches;
            return Searches.Where(x => x.Location.ToLower().StartsWith(filler.ToLower()));
        }

        public IEnumerable<Search> DeleteSearch(int searchId, ObservableCollection<Search> searches)
        {
            return searches.Where(x => x.Id != searchId);
        }
    }
}
