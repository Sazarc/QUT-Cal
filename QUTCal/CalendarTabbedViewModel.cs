using QUTCal.Models;
using QUTCal.Services;
using Syncfusion.SfCalendar.XForms;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace QUTCal
{
    class CalendarTabbedViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation;
        private readonly DatabaseService _databaseService;

        public CalendarTabbedViewModel(INavigation navigation)
        {
            _databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QUTCalDB.db3"));
            Navigation = navigation;

            Classes = new ObservableCollection<Class>();
            LoadClasses();
        }

        public async void LoadClasses()
        {
            Classes = new ObservableCollection<Class>(await _databaseService.GetClassesAsync());
            ClassCalendarEvents = new CalendarEventCollection();
            ClassScheduleAppointments = new ScheduleAppointmentCollection();

            foreach (var _class in Classes)
            {
                var appointment = new CalendarInlineEvent();
                appointment.Subject = _class.Detail;
                appointment.Color = Color.FromHex("#FF6400");
                appointment.StartTime = _class.DateAndTime;
                appointment.EndTime = _class.DateAndTime.AddHours(2);
                this.ClassCalendarEvents.Add(appointment);

                ClassScheduleAppointments.Add(new ScheduleAppointment()
                {
                    StartTime = _class.DateAndTime,
                    EndTime = _class.DateAndTime.AddHours(2),
                    Subject = _class.Detail,
                    Location = _class.Location
                });
            }
        }

        public ObservableCollection<Class> _classes;
        public CalendarEventCollection _classCalendarEvents;
        public ScheduleAppointmentCollection _classScheduleAppointments;

        public ObservableCollection<Class> Classes
        {
            get { return _classes; }
            set
            {
                if (_classes != value)
                {
                    _classes = value;
                    OnPropertyChanged("Classes");
                }
            }
        }

        public CalendarEventCollection ClassCalendarEvents
        {
            get { return _classCalendarEvents; }
            set
            {
                if (_classCalendarEvents != value)
                {
                    _classCalendarEvents = value;
                    OnPropertyChanged("ClassCalendarEvents");
                }
            }
        }

        public ScheduleAppointmentCollection ClassScheduleAppointments
        {
            get { return _classScheduleAppointments; }
            set
            {
                if (_classScheduleAppointments != value)
                {
                    _classScheduleAppointments = value;
                    OnPropertyChanged("ClassScheduleAppointments");
                }
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
