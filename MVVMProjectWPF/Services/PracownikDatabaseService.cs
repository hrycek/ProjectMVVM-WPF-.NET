using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorModes.Model;

namespace ColorModes.Services
{
    public class PracownikDatabaseService
    {
        readonly SQLite.SQLiteAsyncConnection _database;

        public PracownikDatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pracownik>().Wait();
        }

        public Task<List<Pracownik>> GetPracownikAsync()
        {
            return _database.Table<Pracownik>().OrderBy(x => x.Imie).ThenBy(x => x.Nazwisko).ToListAsync();
        }

        public Task<List<Pracownik>> GetPracownikAsyncByIloscZaslug()
        {
            return _database.Table<Pracownik>().OrderByDescending(x => x.IloscZaslug).ToListAsync();
        }

        public Task<int> SavePracownikAsync(Pracownik taskModel)
        {
            return _database.InsertAsync(taskModel);

        }

        public Task<int> EditPracownikAsync(Pracownik taskModel)
        {
            return _database.UpdateAsync(taskModel);

        }

        public Task<int> DeletePracownikAsync(Pracownik taskModel)
        {
            return _database.DeleteAsync(taskModel);

        }
    }
}
