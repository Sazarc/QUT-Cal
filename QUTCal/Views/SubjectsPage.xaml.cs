using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QUTCal.ViewModels;

namespace QUTCal.Views
{
    public partial class SubjectsPage : ContentPage
    {
        SubjectViewModel viewModel;

        public SubjectsPage()
        {
            viewModel = new SubjectViewModel();

            BindingContext = viewModel;

            InitializeComponent();
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddSubject());
        }
    }
}
