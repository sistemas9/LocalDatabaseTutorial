using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDatabaseTutorial
{
  public class DatabaseCarrito
  {
    readonly SQLiteAsyncConnection _database;

    public DatabaseCarrito(string dbPath)
    {
      _database = new SQLiteAsyncConnection(dbPath);
      _database.CreateTableAsync<Carrito>().Wait();
    }

    public Task<List<Carrito>> GetCarritoAsync(String ClaveCarrito)
    {
      return _database.Table<Carrito>().Where(carro => carro.ClaveCarrito == ClaveCarrito).ToListAsync();
    }

    public async Task<Boolean> TruncateCarrito()
    {
      int rowsAffected = await _database.DeleteAllAsync<Carrito>();
      return true;
    }

    public async Task<Double> GetTotalComanda(String ClaveCarrito)
    {
      List<Carrito> carro = _database.Table<Carrito>().Where(carros => carros.ClaveCarrito == ClaveCarrito).ToListAsync().Result;
      Double Totales = carro.Sum(items => items.Monto);
      return Totales;
    }

    public Task<int> SaveCarritoAsync(Carrito carrito)
    {
      return _database.InsertAsync(carrito);
    }

    public Task<int> UpdateCarritoAsync(Carrito carrito)
    {
      return _database.UpdateAsync(carrito);
    }

    public Task<int> DeleteCarritoAsync(Carrito carrito)
    {
      return _database.DeleteAsync(carrito);
    }
  }
}
