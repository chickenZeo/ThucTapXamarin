using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ThucTapXamarin.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public bool IsBlocked { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public ObservableCollection<Contact> GetContacts()
        {
            return new ObservableCollection<Contact>
            {
                new Contact{Id = 1, FirstName = "Hoang", LastName = "Hai Thanh", Email = "hhta@gmail.com", Phone = "08123123", IsBlocked = true },
                new Contact{Id = 2, FirstName = "John", LastName = "Smith", Email = "dasda@gmail.com", Phone = "09993123", IsBlocked = false },
                new Contact{Id = 3, FirstName = "Jack", LastName = "Lewis", Email = "hdgrggmail.com", Phone = "023123", IsBlocked = true },
            };
        }

        
    }
}
