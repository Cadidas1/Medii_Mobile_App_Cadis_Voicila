using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Medii_Mobile_App_Cadis_Voicila.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medii_Mobile_App_Cadis_Voicila.Data
{
    public class InchiriereDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public InchiriereDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Inchiriere>().Wait();
        }
        public Task<List<Inchiriere>> GetInchiriereListAsync()
        {
            return _database.Table<Inchiriere>().ToListAsync();
        }
        public Task<Inchiriere> GetInchiriereAsync(int id)
        {
            return _database.Table<Inchiriere>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveInchiriereAsync(Inchiriere slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteInchiriereAsync(Inchiriere slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
