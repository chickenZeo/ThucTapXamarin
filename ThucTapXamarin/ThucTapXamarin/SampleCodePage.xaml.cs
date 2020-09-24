using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThucTapXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class Contactttt
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class SampleCodePage : ContentPage
    {
        private IList<Contactttt> _listContacts;
        public SampleCodePage()
        {
            InitializeComponent();
            _listContacts = GetContacts();
            foreach (var contact in _listContacts)
                contacMethods.Items.Add(contact.Name);
                
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = contacMethods.Items[contacMethods.SelectedIndex];
           // var contact = _listContacts.Single(x => x.Name == name);

            DisplayAlert("Selection", name, "OK");

        }

        private IList<Contactttt> GetContacts()
        {
            return new List<Contactttt> 
            {
                new Contactttt{ Id = 1, Name = "SMS"},           
                new Contactttt{ Id = 2, Name = "Email"},           
            };
        
        }


        //private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    label.Text = e.NewTextValue;
        //}

        //private void Switch_Toggled(object sender, ToggledEventArgs e)
        //{
        //    label.IsVisible = e.Value;
        //}
    }
}