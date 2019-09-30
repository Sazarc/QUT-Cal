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

namespace QUTCal.ViewModels
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        public ContactsViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            LoadContacts();
            DeleteCommand = new Command<Contact>(delete);
        }

        public void add(Contact contacts)
        {
            Contacts.Add(contacts);
            OnPropertyChanged("Contacts");
        }

        public void delete(Contact contacts)
        {
            Contacts.Remove(contacts);
            OnPropertyChanged("Contacts");
        }

        public void LoadContacts()
        {
            ObservableCollection<Contact> defContacts = Contacts;

            defContacts.Add(new Contact { FirstName = "Shawn", Surname = "Hunter", EmailAddress = "shawnhunter12@gmail.com", PhoneNumber = "0433 582 723" });
            defContacts.Add(new Contact { FirstName = "Alisa", Surname = "Bosconovitch", EmailAddress = "alisab@levosa.com", PhoneNumber = "0456 612 784" });
            defContacts.Add(new Contact { FirstName = "Daniel", Surname = "Viktor", EmailAddress = "dviktor@hotmail.com", PhoneNumber = "0499 146 356" });

            Contacts = defContacts;
        }

        public ICommand DeleteCommand { protected set; get; }

        private ObservableCollection<Contact> _contacts;

        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                if (_contacts != value)
                {
                    _contacts = value;
                    OnPropertyChanged("Contacts");
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