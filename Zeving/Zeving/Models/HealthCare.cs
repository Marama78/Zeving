using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zeving.Models
{
    public class HealthCare
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Site {  get; set; }
        public string Zone { get; set; }
        public string Position { get; set; }

    }
}
