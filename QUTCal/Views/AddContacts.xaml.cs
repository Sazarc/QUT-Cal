using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QUTCal.Models;
using QUTCal.ViewModels;

namespace QUTCal.Views
{
    public partial class AddContacts : ContentPage
    {
        public Contact Contacts { get; set; }

        public AddContacts()
        {
            InitializeComponent();

            Contacts = new Contact
            {
                FirstName = "",
                Surname = "",
                EmailAddress = "",
                PhoneNumber = ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            ContactsViewModel viewModel = (ContactsViewModel)Application.Current.Resources["ContactsViewModel"];
            viewModel.add(Contacts);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

