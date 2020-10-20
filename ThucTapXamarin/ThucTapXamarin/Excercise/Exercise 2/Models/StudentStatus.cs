using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThucTapXamarin.Excercise.Exercise_2.Models
{
    public class StudentStatus
    {
        //[JsonProperty("postId")]
        //public string PostId { get; set; }
       // [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("name")]
        public string Content { get; set; }
       // [JsonProperty("email")]
        public string Status { get; set; }
        //[JsonProperty("body")]
        //public string Body { get; set; }
    }
}
