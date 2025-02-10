using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Zeving.Models;

namespace Zeving.Services
{
    public class TaskTuteurServices
    {
        readonly SQLiteAsyncConnection _database;

        public TaskTuteurServices(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TaskTuteur>().Wait();
        }

        public Task<List<TaskTuteur>> GetListTaskTeurSortedByDateAsync()
        {
            return _database.Table<TaskTuteur>().OrderByDescending(x => x.DueDate).ToListAsync();
        }

        public Task<int> SaveTaskAsync(TaskTuteur taskTuteur)
        {
                return _database.InsertAsync(taskTuteur);
        }

        public async Task<TaskTuteur> LoadDataAsyncById(int id)
        {
            try
            {
                var delta = await _database.Table<TaskTuteur>().FirstOrDefaultAsync(p => p.Id == id);

                return delta;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

            }

            return new TaskTuteur() { NameOfGeographicPosition = "erreur chargement" };

        }



        public async Task<TaskTuteur> LoadDataAsyncByTuteurLocation(string tuteurLocation   )
        {
            try
            {
                var delta = await _database.Table<TaskTuteur>().FirstOrDefaultAsync(p => p.TuteurLocation == tuteurLocation);

                return delta;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

            }

            return null;

        }




        public async Task<bool> UpdateDataAsync(TaskTuteur taskTuteur)
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
              var delta =  await _database.Table<TaskTuteur>().FirstOrDefaultAsync(p=>p.Id == taskId);
            
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
