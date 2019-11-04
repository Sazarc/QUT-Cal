using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QUTCal.Models;
using QUTCal.ViewModels;

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
            if (Subject.Code.Length == 0 || Subject.Text.Length == 0)
            {
                await DisplayAlert("Oops!", "Please fill in every field!", "OK");
            }
            else
            {
                SubjectViewModel viewModel = (SubjectViewModel)Application.Current.Resources["SubjectViewModel"];
                viewModel.add(Subject);
                await Navigation.PopAsync();
            }
        }
    }
}
