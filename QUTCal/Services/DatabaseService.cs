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

            return null;
        }

    }
}
