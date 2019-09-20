using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace QUTCal
{
    class CalendarTabbedViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public CalendarTabbedViewModel(INavigation navigation)
        {
            Navigation = navigation;
            SelectedDate = new DateTime();
            CalendarMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(SelectedDate.Month);

            Reminders = new List<Item>();
            Reminders.Add(new Item("CAB303", "Assignment 1"));
            Reminders.Add(new Item("CAB302", "Assignment 2"));
            Reminders.Add(new Item("CAB101", "Final Exam"));
            Reminders.Add(new Item("CAB101", "Final Exam"));
            Reminders.Add(new Item("CAB101", "Final Exam"));
            Reminders.Add(new Item("CAB101", "Final Exam"));
            Reminders.Add(new Item("CAB101", "Final Exam"));
            Reminders.Add(new Item("CAB101", "Final Exam"));
            Reminders.Add(new Item("CAB101", "Final Exam"));
            Reminders.Add(new Item("CAB101", "Final Exam"));
        }



        public INavigation Navigation;
        public DateTime SelectedDate { get; set; }
        public string CalendarMonth { get; }
        public List<Item> Reminders { get; set; }

    }
}
