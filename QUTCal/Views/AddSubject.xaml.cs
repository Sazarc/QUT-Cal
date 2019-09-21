using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QUTCal.Models;

namespace QUTCal.Views
{
    public partial class AddSubject : ContentPage
    {
        public Subject Subject { get; set; }

        public AddSubject()
        {
            InitializeComponent();

            Subject = new Subject
            {
                Code = "",
                Text = ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Subject);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
