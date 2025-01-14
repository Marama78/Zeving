using SQLite;
using System;

namespace Zeving.Models
{
    public class DailyNavigate
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DateAction { get; set; }
        public string Note { get; set; }

    }
}
