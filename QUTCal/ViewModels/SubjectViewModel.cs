using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using QUTCal.Models;
using QUTCal.Views;
using QUTCal.Services;
using System.IO;

namespace QUTCal.ViewModels
{
    public class SubjectViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        public SubjectViewModel()
        {
            _databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QUTCalDB.db3"));
            Subjects = new ObservableCollection<Subject>();
            LoadSubjects();
            DeleteCommand = new Command<Subject>(delete);
        }

        public ObservableCollection<Subject> Subjects { get; set; }

        public async void add(Subject subject)
        {
            subject.Id = await _databaseService.SaveSubject(subject);

            Subjects.Add(subject);
            OnPropertyChanged("Subjects");
        }

        public void delete(Subject subject)
        {
            Subjects.Remove(subject);
            OnPropertyChanged("Subjects");
        }
        
        public async void LoadSubjects()
        {
            Subjects = new ObservableCollection<Subject>(await _databaseService.GetSubjectsAsync());

            /*
            ObservableCollection<Subject> defSubjects = Subjects;

            defSubjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "CAB303", Text = "Networks" });
            defSubjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "CAB432", Text = "Cloud Computing" });
            defSubjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "IAB330", Text = "Mobile Application Development" });

            Subjects = defSubjects;
            */
        }

        public ICommand DeleteCommand { protected set; get; }

        private ObservableCollection<Subject> _subjects;

        public ObservableCollection<Subject> Subjects
        {
            get { return _subjects; }
            set
            {
                if (_subjects != value)
                {
                    _subjects = value;
                    OnPropertyChanged("Subjects");
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