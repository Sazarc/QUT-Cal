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
        public Class Class { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime endDate { get; set; }

        public AddClass()
        {
            InitializeComponent();
            Time = new TimeSpan();
            Class = new Class();
            Class.DateAndTime = DateTime.Now.Date;
            endDate = new DateTime();

            BindingContext = this;
        }

        private async void CreateClass_OnClick(object sender, EventArgs e)
        {
            Debug.WriteLine(Class.DateAndTime);
            Class.DateAndTime = Class.DateAndTime.Add(Time);
            Debug.WriteLine(Class.DateAndTime);
            ClassViewModel viewModel = (ClassViewModel) Application.Current.Resources["ClassViewModel"];
            Debug.WriteLine(endDate);
            viewModel.add(Class, endDate);
            await Navigation.PopAsync();
        }

        private void UnitPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker) sender;
            var selectedIndex = picker.SelectedIndex;

            if (selectedIndex == -1) return;
            var picked = (Subject) picker.ItemsSource[selectedIndex];
            Class.UnitCode = picked.Code;
        }

        private void TypePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedIndex = picker.SelectedIndex;

            if (selectedIndex == -1) return;
            string picked = (string) picker.ItemsSource[selectedIndex];
            Class.ClassType = picked;
        }
    }
}
