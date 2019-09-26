using System;
using QUTCal.Models;
using System.ComponentModel;
using SQLite;

namespace QUTCal.Models
{

    public class Class : INotifyPropertyChanged
    {
        private int id { get; set; }
        private string unitCode;
        private string classType;
        private string location;
        private DateTime dateAndTime;

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

        public string UnitCode
        {
            get { return unitCode; }

            set
            {
                if (unitCode != value)
                {
                    unitCode = value;
                    RaisePropertyChanged("UnitCode");
                }
            }
        }

        public string ClassType
        {
            get
            {
                return classType;
            }

            set
            {
                if (classType != value)
                {
                    classType = value;
                    RaisePropertyChanged("ClassType");
                }
            }
        }
        
        public DateTime DateAndTime
        {
            get { return dateAndTime; }

            set
            {
                if (dateAndTime != value)
                {
                    dateAndTime = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        public string Location
        {
            get { return location; }

            set
            {
                if(location != value)
                {
                    location = value;
                    RaisePropertyChanged("Location");
                }
            }
        }

        public string Detail
        {
            get
            {
                return unitCode + " - " + classType;
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