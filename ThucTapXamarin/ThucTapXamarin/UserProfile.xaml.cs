using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ThucTapXamarin.Models;

namespace ThucTapXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfile : ContentPage
    {
        private UserService _userService = new UserService();
        public UserProfile(int userId )
        {
            InitializeComponent();
            BindingContext = _userService.GetUser(userId);
        }
    }
}