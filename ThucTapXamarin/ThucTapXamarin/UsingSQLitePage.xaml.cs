using SQLite;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using ThucTapXamarin.Presistence;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThucTapXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsingSQLitePage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _listRecipes;
        public class Recipe : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            private string _name;
            [MaxLength(255)]
            public string Name 
            {
                get { return _name; } 
                set
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public UsingSQLitePage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();


        }
        //Best practice
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _connection.CreateTableAsync<Recipe>();
            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _listRecipes = new ObservableCollection<Recipe>(recipes);
            listViewRecips.ItemsSource = _listRecipes;
        }

        private async void OnAddBtn_Clicked(object sender, EventArgs e)
        {
            
            var recipes = new Recipe { Name = "Thanh" + DateTime.Now };
            await _connection.InsertAsync(recipes);
            _listRecipes.Add(recipes);
        }

        private async void OnUpdateBtn_Clicked(object sender, EventArgs e)
        {
            var recipe = _listRecipes[0];
            recipe.Name += "Hi Hi ha ha";
            await _connection.UpdateAsync(recipe);
        }

        private async void OnDeleteBtn_Clicked(object sender, EventArgs e)
        {
            if (!_listRecipes.Any())
                await DisplayAlert("Meesage", "There are no Recipe in list", "OK");
            else
            {
                var deletedRecipe = _listRecipes[0];
                await _connection.DeleteAsync(deletedRecipe);
                _listRecipes.Remove(deletedRecipe);
            }
            
        }
    }
}