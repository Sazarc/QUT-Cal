using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QUTCal.Models;

namespace QUTCal
{
    public partial class AddClass : ContentPage
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private async void CreateClass_OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddClass());
        }

    }
}
