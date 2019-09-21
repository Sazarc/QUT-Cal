﻿using System;
using QUTCal.Models;
using System.ComponentModel;

namespace QUTCal.Models
{

    public class Subject : INotifyPropertyChanged
    {
        private string id;
        private string code;
        private string text;

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
                    RaisePropertyChanged("Unit");
                }
            }
        }

        public string Code
        {
            get { return code; }

            set
            {
                if (code != value)
                {
                    code = value;
                    RaisePropertyChanged("Code");
                    RaisePropertyChanged("Unit");
                }
            }
        }

        public string Text
        {
            get { return text; }

            set
            {
                if (text != value)
                {
                    text = value;
                    RaisePropertyChanged("Text");
                    RaisePropertyChanged("Unit");
                }
            }
        }

        public string Unit
        {
            get
            {
                return code + " - " + text;
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