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
        public ObservableCollection<Search> _searches;
        //public IEnumerable<Search> GetSearches(string filler = null)
        //{
        //    if (String.IsNullOrWhiteSpace(filler))
        //        return _searches;
        //    return _searches.Where(x => x.Location.StartsWith(filler));
        //}

        public void DeleteSearch(int searchId)
        {
            _searches.Remove((Search)_searches.Where(x => x.Id == searchId));
        }
    }
}
