using System;
using QUTCal.Models;
using System.ComponentModel;
using SQLite;

namespace QUTCal.Models
{

    public class Contact : INotifyPropertyChanged
    {
        private int id { get; set; }
        private string firstname;
        private string surname;
        private string emailaddress;
        private string phonenumber;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public string FirstName
        {
            get
            {
                return firstname;
            }

            set
            {
                if (firstname != value)
                {
                    firstname = value;
                    RaisePropertyChanged("First Name");
                }
            }
        }

        public string Surname
        {
            get { return surname; }

            set
            {
                if (surname != value)
                {
                    surname = value;
                    RaisePropertyChanged("Surname");
                }
            }
        }

        public string FullName
        {
            get
            {
                return firstname + " " + surname;
            }
        }

        public string EmailAddress
        {
            get
            {
                return emailaddress;
            }

            set
            {
                if (emailaddress != value)
                {
                    emailaddress = value;
                    RaisePropertyChanged("Email Address");
                }
            }
        }

        public string PhoneNumber
        {
            get { return phonenumber; }

            set
            {
                if (phonenumber != value)
                {
                    phonenumber = value;
                    RaisePropertyChanged("Phone Number");
                }
            }
        }

        public string PersonalDetails
        {
            get
            {
                return emailaddress + " " + phonenumber;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
