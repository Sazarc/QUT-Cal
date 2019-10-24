using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QUTCal.Models;

namespace QUTCal.Views
{
    public partial class ClassesPage : ContentPage
    {
        public ClassesPage()
        {
            InitializeComponent();
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddClass());
        }

        private async void Item_Clicked(object sender, ItemTappedEventArgs e)
        {
            Class selectedClass = (Class)e.Item;
            await DisplayAlert(selectedClass.Detail, selectedClass.Location + "\n" + selectedClass.DateAndTime.ToLongDateString()
                 + "\n" + selectedClass.DateAndTime.ToLongTimeString(), "OK");  
        }
    }
}
