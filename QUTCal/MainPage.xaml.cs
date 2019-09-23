﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using QUTCal.Views;

namespace QUTCal
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainPageViewModel(Navigation);
            InitializeComponent();
        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClassesPage());
        }
    }
}
