using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net.Http;
using ThucTapXamarin.Excercise.Exercise_2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThucTapXamarin.Excercise.Exercise_2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsPage : ContentPage
    {
        private List<StudentStatus> _listStudents;
        private HttpClient _client = new HttpClient();
        private const string Url = "http://api.hkids.edu.vn/api/v1/Notification/All?ClassId=8145646c-4cdc-4a0e-9fe0-7ca9d4c63af0&SchoolId=4bba3fd1-ce85-44de-918c-d6cbf9fb8852";

        public static readonly BindableProperty IsSearchingProperty = BindableProperty.Create("IsSearching", typeof(bool), typeof(StudentsPage), false);
        public string IsSearching
        {
            get { return (string)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }
        }
        public StudentsPage()
        {
            InitializeComponent();
            //BindingContext = this;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //var client = new RestClient();
            //client.BaseUrl = new System.Uri(Url);
            //client.Timeout = 10000;
            //var request = new RestRequest(Method.GET);
            //var response = await client.ExecuteAsync<object>(request);
            //System.Console.WriteLine();

            var response = await _client.GetAsync(Url);
            var content = await response.Content.ReadAsStringAsync();
            var student = JsonConvert.DeserializeObject<List<StudentStatus>>(content);
            _listStudents = new List<StudentStatus>(student);
            listStudents.ItemsSource = _listStudents;


        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}