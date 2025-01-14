using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Zeving.Models;

namespace Zeving.Services
{
    public class DailyNavigateServices
    {
        readonly SQLiteAsyncConnection _database;

        public DailyNavigateServices(String dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DailyNavigate>().Wait();
        }

    }
}
