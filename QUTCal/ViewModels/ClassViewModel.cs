using System;
using System.Collections.ObjectModel;

using QUTCal.Models;
using QUTCal.Views;

namespace QUTCal.ViewModels
{
    public class ClassViewModel
    {
        public ClassViewModel()
        {
            Classes = new ObservableCollection<Class>();

            LoadSubjects();
        }

        public ObservableCollection<Class> Classes { get; set; }

        public void add(Class _class)
        {
            _class.Id = Guid.NewGuid().ToString();

            Classes.Add(_class);
        }

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
    }
}