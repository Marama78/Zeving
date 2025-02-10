using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Zeving.Models;

namespace Zeving.Services
{
    public class SerrePlanificatorServices
    {
        readonly SQLiteAsyncConnection _database;

        public SerrePlanificatorServices(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SerrePlanificator>().Wait();
        }



        public Task<List<SerrePlanificator>> GetListSortedByDateAsync()
        {
            return _database.Table<SerrePlanificator>().OrderByDescending(x => x.Id).ToListAsync();
        }

        public Task<int> SaveAsync(SerrePlanificator item)
        {
            return _database.InsertAsync(item);
        }

        public async Task<SerrePlanificator> LoadDataAsyncById(int id)
        {
            try
            {
                var delta = await _database.Table<SerrePlanificator>().FirstOrDefaultAsync(p => p.Id == id);

                return delta;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return new SerrePlanificator();

        }

        public async Task<bool> UpdateDataAsync(SerrePlanificator taskTuteur)
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
                var delta = await _database.Table<SerrePlanificator>().FirstOrDefaultAsync(p => p.Id == taskId);

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
