using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using QUTCal.Models;

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
        private async void Item_clicked(object sender, ItemTappedEventArgs e)
        {
            Contact selectedContact = (Contact)e.Item;
            string action = await DisplayActionSheet(selectedContact.Name, "Cancel", null, "Email", "Call");
            
            if(action == "Email")
            {
                try
                {
                    var message = new EmailMessage
                    {
                        To = new List<string>() { selectedContact.EmailAddress }
                    };
                    await Email.ComposeAsync(message);
                }
                catch (FeatureNotSupportedException)
                {
                    await DisplayAlert("Oops!","This device does not support email sending", "OK");
                }
                catch (Exception)
                {
                    await DisplayAlert("Oops!", "Unknown error occurred", "OK");
                }
            }
            else if(action == "Call")
            {
                try
                {
                    PhoneDialer.Open(selectedContact.PhoneNumber);
                }
                catch (ArgumentException)
                {
                    await DisplayAlert("Oops!", "Phone number is formatted incorrectly", "OK");
                }
                catch (FeatureNotSupportedException)
                {
                    await DisplayAlert("Oops!", "This device does not support calling", "OK");
                }
                catch (Exception)
                {
                    await DisplayAlert("Oops!", "Unknown error occurred", "OK");
                }
            }
        }

    }
}