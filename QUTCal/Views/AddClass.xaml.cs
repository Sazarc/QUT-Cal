using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QUTCal.Models;
using QUTCal.ViewModels;

namespace QUTCal
{
    public partial class AddClass : ContentPage
    {
        public Class Class { get; set; }
        public SubjectViewModel SubjectVM;


        public AddClass()
        {
            SubjectVM = (SubjectViewModel) Application.Current.Resources["SubjectViewModel"];

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

            await Navigation.PopAsync();
        }

    }
}
