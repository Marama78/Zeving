using SQLite;

namespace Zeving.Models
{
    public class SerrePlanificator
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public string Site { get; set; }
        public string Zone { get; set; }
        public string Position { get; set; }
        public TaskTuteur TaskTuteurData { get; set; }

    }
}
