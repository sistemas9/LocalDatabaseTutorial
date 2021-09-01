using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace LocalDatabaseTutorial
{
  public class Database
  {
    readonly SQLiteAsyncConnection _database;

    public Database(string dbPath)
    {
      _database = new SQLiteAsyncConnection(dbPath);
      _database.CreateTableAsync<Guisos>().Wait();
    }

    public Task<List<Guisos>> GetPeopleAsync()
    {
      return _database.Table<Guisos>().ToListAsync();
    }

    public Task<int> SavePersonAsync(Guisos guiso)
    {
      return _database.InsertAsync(guiso);
    }

    public Task<int> UpdateGuisoAsync(Guisos guiso)
    {
      return _database.UpdateAsync(guiso);
    }

    public Task<int> DeleteGuisoAsync(Guisos guiso)
    {
      return _database.DeleteAsync(guiso);
    }
  }
}
