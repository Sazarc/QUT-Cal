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
            LoadSubjects();

            MessagingCenter.Subscribe<AddSubject, Subject>(this, "AddSubject", async (obj, subject) =>
            {
                var newSubject = subject as Subject;
                Subjects.Add(newSubject);
            });
        }

        public ObservableCollection<Subject> Subjects
        {
            get;
            set;
        }

        public void LoadSubjects()
        {
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();

            subjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "CAB303", Text = "Networks" });
            subjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "CAB432", Text = "Cloud Computing" });
            subjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Code = "IAB330", Text = "Mobile Application Development" });

            Subjects = subjects;
        }
    }
}