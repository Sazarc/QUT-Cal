using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using QUTCal.Models;
using QUTCal.ViewModels;

namespace QUTCal.Views
{
    public partial class AddClass : ContentPage
    {
        private Class Class { get; set; }

        public AddClass()
        {
            InitializeComponent();

            Class = new Class
            {
                UnitCode = "",
                ClassType = "",
                Location = "",
                DateAndTime = new DateTime()
            };

            BindingContext = this;
        }

        private async void CreateClass_OnClick(object sender, EventArgs e)
        {
            Debug.WriteLine(Class.DateAndTime.ToString());
            await Navigation.PopAsync();
        }

        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker) sender;
            var selectedIndex = picker.SelectedIndex;

            if (selectedIndex == -1) return;
            var picked = (Subject) picker.ItemsSource[selectedIndex];
            Class.UnitCode = picked.Code;
        }
    }
}
