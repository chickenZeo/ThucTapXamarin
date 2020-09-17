using System;
using System.Collections.Generic;
using System.Text;

namespace ThucTapXamarin.Models
{
    public class Activity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get { return $"ui{UserId}.jpg"; } }
    }
}
