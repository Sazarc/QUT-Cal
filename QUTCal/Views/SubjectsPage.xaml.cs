using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QUTCal.ViewModels;

namespace QUTCal.Views
{
    public partial class SubjectsPage : ContentPage
    {
        SubjectsViewModel viewModel;

        public SubjectsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SubjectsViewModel();
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddSubject());
        }
    }
}
