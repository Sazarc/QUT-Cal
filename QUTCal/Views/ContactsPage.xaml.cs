using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QUTCal.ViewModels;

namespace QUTCal.Views
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContacts());
        }
    }
}