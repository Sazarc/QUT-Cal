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
            Class = new Class
            {
                DateAndTime = DateTime.Now.Date,
                Location = "",
                UnitCode = "",
                ClassType = ""
            };
            endDate = new DateTime();

            BindingContext = this;
        }

        private async void CreateClass_OnClick(object sender, EventArgs e)
        {
            Debug.WriteLine(Class.ClassType);
            Debug.WriteLine(Class.UnitCode);
            Debug.WriteLine(Class.Location);
            if (Class.ClassType.Length == 0 || Class.UnitCode.Length == 0 || Class.Location.Length == 0)
            {
                await DisplayAlert("Oops!", "Please fill in every field!", "OK");
            }
            else
            {
                Class.DateAndTime = Class.DateAndTime.Add(Time);

                ClassViewModel viewModel = (ClassViewModel)Application.Current.Resources["ClassViewModel"];
                viewModel.add(Class, endDate);

                if (viewModel.Repeat)
                {
                    while (true)
                    {
                        if (Class.DateAndTime.AddDays(7).Date <= endDate.Date)
                        {
                            Class.DateAndTime = Class.DateAndTime.AddDays(7);
                            await viewModel.add(Class);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                await Navigation.PopAsync();
            }
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
