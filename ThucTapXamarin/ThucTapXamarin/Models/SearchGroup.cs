using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Text;
using Xamarin.Forms;

namespace ThucTapXamarin.Models
{
    public class SearchGroup : ObservableCollection<Search>
    {
        public string Title { get; set; }
        public SearchGroup(string title, ObservableCollection<Search> searches) : base(searches)
        {
            Title = title;
        }
    }
}
