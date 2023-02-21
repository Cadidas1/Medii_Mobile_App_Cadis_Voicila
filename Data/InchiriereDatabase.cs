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
            _database.CreateTableAsync<Masina>().Wait();
            _database.CreateTableAsync<ListMasina>().Wait();
        }

        public Task<int> SaveListMasinaAsync(ListMasina listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Masina>> GetListMasiniAsync(int inchiriereid)
        {
            return _database.QueryAsync<Masina>(
            "select P.ID, P.Description from Masina P"
            + " inner join ListMasina LP"
            + " on P.ID = LP.MasinaID where LP.InchiriereID = ?",
            inchiriereid);
        }
        public Task<int> SaveMasinaAsync(Masina masina)
        {
            if (masina.ID != 0)
            {
                return _database.UpdateAsync(masina);
            }
            else
            {
                return _database.InsertAsync(masina);
            }
        }
        public Task<int> DeleteMasinaAsync(Masina masina)
        {
            return _database.DeleteAsync(masina);
        }
        public Task<List<Masina>> GetMasiniAsync()

        {
            return _database.Table<Masina>().ToListAsync();
        }

        public Task<List<Inchiriere>> GetInchirieriAsync()
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