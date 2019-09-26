using QUTCal.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QUTCal.Services
{
    class DatabaseService
    {

        readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Class>().Wait();
            _database.CreateTableAsync<Subject>().Wait();
        }

        public Task<List<Class>> GetClassesAsync()
        {
            return _database.Table<Class>().ToListAsync();
        }

        public Task<Class> GetClassById(Class _class)
        {
            return _database.Table<Class>()
                .Where(i => i.Id == _class.Id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveClass(Class _class)
        {
            if (_class.Id == 0)
            {
                // New class
                return _database.InsertAsync(_class);
            }
            else
            {
                return _database.UpdateAsync(_class);
            }
        }

        public Task<int> RemoveClass(Class _class)
        {
            return _database.DeleteAsync(_class);
        }

        public Task<List<Subject>> GetSubjectsAsync()
        {
            return _database.Table<Subject>().ToListAsync();
        }

        public Task<Subject> GetSubjectById(Subject subject)
        {
            return _database.Table<Subject>()
                .Where(i => i.Id == subject.Id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveSubject(Subject subject)
        {
            if (subject.Id == 0)
            {
                // New subject
                return _database.InsertAsync(subject);
            }
            else
            {
                return _database.UpdateAsync(subject);
            }
        }

        public Task<int> RemoveSubject(Subject subject)
        {
            return _database.DeleteAsync(subject);
        }

    }
}
