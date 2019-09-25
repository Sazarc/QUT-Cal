using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using QUTCal.Models;
using QUTCal.Views;

namespace QUTCal.ViewModels
{
    public class SubjectViewModel
    {
        public SubjectViewModel()
        {
            Subjects = new ObservableCollection<Subject>();

            LoadSubjects();
        }

        public ObservableCollection<Subject> Subjects { get; set; }

        public void add(Subject subject)
        {
            subject.Id = Guid.NewGuid().ToString();

            Subjects.Add(subject);
        }

        public void LoadSubjects()
        {
            ObservableCollection<Subject> defSubjects = Subjects;

            defSubjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "CAB303", Text = "Networks" });
            defSubjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "CAB432", Text = "Cloud Computing" });
            defSubjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "IAB330", Text = "Mobile Application Development" });

            Subjects = defSubjects;
        }
    }
}