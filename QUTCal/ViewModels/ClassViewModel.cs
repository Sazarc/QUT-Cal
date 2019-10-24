using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.IO;
using QUTCal.Models;
using QUTCal.Services;
using QUTCal.Views;
using Xamarin.Forms;

namespace QUTCal.ViewModels
{
    public class ClassViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;
        private bool repeat;

        public ICommand DeleteCommand { protected set; get; }

        public ClassViewModel()
        {
            _databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QUTCalDB.db3"));
            Classes = new ObservableCollection<Class>();
            LoadClasses();
            
            DeleteCommand = new Command<Class>(delete);
        }

        public void add(Class _class, DateTime endDate)
        {
            // Perform the save operation on the database,
            // and update the model with the newly created ID.
            _class.Id = _databaseService.SaveClass(_class).Result;

            Classes.Add(_class);

            // Perform repeating class
            if (repeat)
            {
                while (true)
                {
                    if(_class.DateAndTime.AddDays(7).Date <= endDate.Date)
                    {
                        _class.DateAndTime = _class.DateAndTime.AddDays(7);

                        _class.Id = _databaseService.SaveClass(_class).Result;

                        Classes.Add(_class);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            OnPropertyChanged("Classes");
        }

        public bool Repeat
        {
            get
            {
                return repeat;
            }
            set
            {
                if (repeat != value)
                {
                    repeat = value;
                    RaisePropertyChanged("Repeat");
                }
            }
        }


        // Keep the observable collection up to date.
        public ObservableCollection<Class> ClassesInDate(DateTime date)
        {
            ObservableCollection<Class> classesInDate = new ObservableCollection<Class>();

            foreach (Class _class in Classes)
            {
                if(_class.DateAndTime.Date == date.Date)
                {
                    classesInDate.Add(_class);
                }
            }

            return classesInDate;
        }

        public void delete(Class _class)
        {
            // Keep the observable collection up to date.
            Classes.Remove(_class);
            OnPropertyChanged("Classes");

            // Perform the remove operation on the database.
            _databaseService.RemoveClass(_class);
        }

        public async void LoadClasses()
        {
            Classes = new ObservableCollection<Class>(await _databaseService.GetClassesAsync());
        }

        public ObservableCollection<Class> _classes;

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
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}