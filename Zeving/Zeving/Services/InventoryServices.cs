using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Zeving.Models;

namespace Zeving.Services
{
    public class InventoryServices
    {
       readonly SQLiteAsyncConnection _database;

        public InventoryServices(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Inventory>().Wait();
        }

        public Task<List<Inventory>> GetListSortedByDateAsync()
        {
            return _database.Table<Inventory>().OrderByDescending(x => x.Family).ToListAsync();
        }

        public Task<int> SaveAsync(Inventory item)
        {
            return _database.InsertAsync(item);
        }

        public async Task<Inventory> LoadDataAsyncById(int id)
        {
            try
            {
                var delta = await _database.Table<Inventory>().FirstOrDefaultAsync(p => p.Id == id);

                return delta;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

            }

            return new Inventory();

        }

        public async Task<bool> UpdateDataAsync(Inventory taskTuteur)
        {
            try
            {
                await _database.UpdateAsync(taskTuteur);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return false;
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            try
            {
                var delta = await _database.Table<Inventory>().FirstOrDefaultAsync(p => p.Id == taskId);

                await _database.DeleteAsync(delta);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return false;
        }






    }
}
