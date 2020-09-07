using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ThucTapXamarin.Models
{
    public class ContactGroup : List<Contact>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }

        public ContactGroup (string title, string shortTitle)
        {
            Title = title;
            ShortTitle = shortTitle;
        }
    }
}
