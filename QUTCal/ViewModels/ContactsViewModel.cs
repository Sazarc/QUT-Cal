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
    public class ContactsViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        public ICommand DeleteCommand { protected set; get; }

        public ContactsViewModel()
        {
            _databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QUTCalDB.db3"));
            Contacts = new ObservableCollection<Contact>();
            LoadContacts();

            DeleteCommand = new Command<Contact>(delete);
        }

        public async void add(Contact contact)
        {
            // Perform the save operation on the database,
            // and update the model with the newly created ID.
            contact.Id = await _databaseService.SaveContact(contact);

            Contacts.Add(contact);
            OnPropertyChanged("Contacts");
        }

        public async void delete(Contact contact)
        {
            // Keep the observable collection up to date.
            Contacts.Remove(contact);
            OnPropertyChanged("Contacts");

            // Perform the remove operation on the database.
            _ = _databaseService.RemoveContact(contact);
        }

        public async void LoadContacts()
        {
            Contacts = new ObservableCollection<Contact>(await _databaseService.GetContactsAsync());
        }

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