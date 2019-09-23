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
        private ObservableCollection<Subject> subjects;

        public SubjectViewModel()
        {
            subjects = new ObservableCollection<Subject>();

            LoadSubjects();

            MessagingCenter.Subscribe<AddSubject, Subject>(this, "AddSubject", async (obj, subject) =>
            {
                var newSubject = subject as Subject;
                Subjects.Add(newSubject);
            });
        }

        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }

        public void add(Subject subject)
        {
            subjects.Add(subject);
        }

        public void LoadSubjects()
        {
            ObservableCollection<Subject> defSubjects = subjects;

            defSubjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "CAB303", Text = "Networks" });
            defSubjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "CAB432", Text = "Cloud Computing" });
            defSubjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "IAB330", Text = "Mobile Application Development" });

            Subjects = subjects;
        }
    }
}