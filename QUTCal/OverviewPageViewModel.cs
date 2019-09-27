using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace QUTCal
{
    class MainPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GotoCalendarViewCommand = new Command(() => { Navigation.PushAsync(new CalendarTabbedPage()); });
        }

        public INavigation Navigation;
        public ICommand GotoCalendarViewCommand { private set; get; }

    }
}
