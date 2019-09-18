using System;
using System.Collections.Generic;

using Xamarin.Forms;

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
    }
}
