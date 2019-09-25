using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QUTCal.Models;

namespace QUTCal.Services
{
    public class SubjectSample : SubjectDataStore<Subject>
    {
        List<Subject> subjects;

        public SubjectSample()
        {
            subjects = new List<Subject>();
            var mockSubjects = new List<Subject>
            {
                new Subject { Id = Guid.NewGuid().ToString(), Code = "IFB105", Text="Database Management" },
                new Subject { Id = Guid.NewGuid().ToString(), Code = "IAB206", Text="Modern Data Management" },
                new Subject { Id = Guid.NewGuid().ToString(), Code = "IAB207", Text="Rapid Web Application Development" },
                new Subject { Id = Guid.NewGuid().ToString(), Code = "IAB330", Text="Mobile Application Development" }
            };

            foreach (var item in mockSubjects)
            {
                subjects.Add(item);
            }
        }

        public async Task<bool> AddSubjectAsync(Subject item)
        {
            subjects.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateSubjectAsync(Subject item)
        {
            var oldSubject = subjects.Where((Subject arg) => arg.Id == item.Id).FirstOrDefault();
            subjects.Remove(oldSubject);
            subjects.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteSubjectAsync(string id)
        {
            var oldSubject = subjects.Where((Subject arg) => arg.Id == id).FirstOrDefault();
            subjects.Remove(oldSubject);

            return await Task.FromResult(true);
        }

        public async Task<Subject> GetSubjectAsync(string id)
        {
            return await Task.FromResult(subjects.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Subject>> GetSubjectsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(subjects);
        }
    }
}
