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

        public ICommand DeleteCommand { protected set; get; }
        public ICommand ReloadCommand { protected set; get; }

        public ClassViewModel()
        {
            _databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QUTCalDB.db3"));
            Classes = new ObservableCollection<Class>();
            LoadClasses();
            
            DeleteCommand = new Command<Class>(delete);
            ReloadCommand = new Command(reload);
        }

        public async void add(Class _class)
        {
            // Perform the save operation on the database,
            // and update the model with the newly created ID.
            _class.Id = await _databaseService.SaveClass(_class);

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

        public void add(Class _class)
        {
            Classes.Add(_class);
            OnPropertyChanged("Classes");
        }

        public void delete(Class _class)
        {
            // Keep the observable collection up to date.
            Classes.Remove(_class);
            OnPropertyChanged("Classes");

            // Perform the remove operation on the database.
            _databaseService.RemoveClass(_class);
        }

        public void reload()
        {
            Classes = new ObservableCollection<Class>();
            LoadClasses();
            OnPropertyChanged("Classes");
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
        #endregion
    }
}