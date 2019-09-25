﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QUTCal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarTabbedPage : TabbedPage
    {
        public CalendarTabbedPage()
        {
            BindingContext = new CalendarTabbedViewModel(Navigation);
            InitializeComponent();
        }

    }
}