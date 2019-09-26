using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using QUTCal.Models;
using QUTCal.Views;
using Xamarin.Forms;

namespace QUTCal.ViewModels
{
    public class ClassViewModel : INotifyPropertyChanged
    {
        public ClassViewModel()
        {
            Classes = new ObservableCollection<Class>();
            LoadSubjects();
            DeleteCommand = new Command<Class>(delete);
        }

        public ObservableCollection<Class> Classes { get; set; }

        public void add(Class _class)
        {
            Classes.Add(_class);
            OnPropertyChanged("Classes");
        }
        
        public ICommand DeleteCommand { protected set; get; }

        public void LoadSubjects()
        {
            ObservableCollection<Class> defClasses = Classes;

            defClasses.Add(new Class { Id = Guid.NewGuid().ToString(), UnitCode = "CAB303", ClassType = "Lecture", Location = "S513",
                DateAndTime = new DateTime(2019, 9, 23, 15, 0, 0) });
            defClasses.Add(new Class { Id = Guid.NewGuid().ToString(), UnitCode = "CAB432", ClassType = "Practical", Location = "G216", 
                DateAndTime = new DateTime(2019, 9, 25, 15, 0, 0) });
            defClasses.Add(new Class { Id = Guid.NewGuid().ToString(), UnitCode = "IAB330", ClassType = "Tutorial", Location = "F101", 
                DateAndTime = new DateTime(2019, 10, 3, 15, 0, 0) });

            Classes = defClasses;
        }
        
        public void delete(Class _class)
        {
            Classes.Remove(_class);
            OnPropertyChanged("Classes");
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