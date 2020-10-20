
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace ThucTapXamarin.Models
{
    public class Contact : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName 
        { 
            get
            {
                return firstName;
            }

            set
            {
                if(firstName == value)
                    return;
                firstName = value;
                OnPropertyChanged(FirstName);
                OnPropertyChanged(nameof(FullName));
            } 
        }
        public string LastName 
        {
            get
            {
                return lastName;
            }

            set
            {
                if (lastName == value)
                    return;
                lastName = value;
                OnPropertyChanged(LastName);
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public event PropertyChangedEventHandler PropertyChanged;

        //public ObservableCollection<Contact> GetContacts()
        //{
        //    return new ObservableCollection<Contact>
        //    {
        //        new Contact { Id = 1, FirstName = "Hoang", LastName = "Hai Thanh", Phone= "01236666", IsBlocked = false},
        //        new Contact { Id = 2, FirstName = "KICM", LastName = "Khanh", Phone= "012329999", IsBlocked = true},
        //        new Contact { Id = 3, FirstName = "Jacky", LastName = "Chan", Phone= "01232500015", IsBlocked = true}
        //    };
        //}

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
