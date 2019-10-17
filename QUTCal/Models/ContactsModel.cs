using System;
using QUTCal.Models;
using System.ComponentModel;
using SQLite;

namespace QUTCal.Models
{

    public class Contact : INotifyPropertyChanged
    {
        private int id { get; set; }
        private string name;
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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
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

        public static Contact ID(int id)
        {
            Contact c = new Contact();
            c.Id = id;
            return c;
        }
    }
}
