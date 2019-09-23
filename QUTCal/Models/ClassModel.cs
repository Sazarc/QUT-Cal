using System;
using QUTCal.Models;
using System.ComponentModel;

namespace QUTCal.Models
{

    public class Class : INotifyPropertyChanged
    {
        private string id;
        private string unitCode;
        private string classType;
        private DateTime dateTime;

        public string Id
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
            get { return dateTime; }

            set
            {
                if (dateTime != value)
                {
                    dateTime = value;
                    RaisePropertyChanged("DateAndTime");
                }
            }
        }

        public string _Class
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