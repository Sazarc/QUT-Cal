using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using QUTCal.Models;
using QUTCal.Views;

namespace QUTCal.ViewModels
{
    public class SubjectsViewModel : ShellBaseViewModel
    {
        public ObservableCollection<Subject> Subjects { get; set; }
        public Command LoadSubjectsCommand { get; set; }

        public SubjectsViewModel()
        {
            Title = "Browse";
            Subjects = new ObservableCollection<Subject>();
            LoadSubjectsCommand = new Command(async () => await ExecuteLoadSubjectsCommand());

            MessagingCenter.Subscribe<AddSubject, Subject>(this, "AddSubject", async (obj, subject) =>
            {
                var newSubject = subject as Subject;
                Subjects.Add(newSubject);
                await DataStore.AddSubjectAsync(newSubject);
            });
        }

        async Task ExecuteLoadSubjectsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Subjects.Clear();
                var subjects = await DataStore.GetSubjectsAsync(true);
                foreach (var subject in subjects)
                {
                    Subjects.Add(subject);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}