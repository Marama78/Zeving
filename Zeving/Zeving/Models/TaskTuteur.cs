using System;
using SQLite;

namespace Zeving.Models
{
    public class TaskTuteur
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public bool Toremove { get; set; }
        public string NameOfGeographicPosition { get; set; }
        public string NameOfInsideLocation { get; set; }
        public string NameOfVanillaLocation { get; set; }

        public bool IsAddCompost { get; set; }
        public bool IsAddSlugKiller { get; set; }
        public bool IsNeedsHealling { get; set; }
        public bool IsNeedsFeeding { get; set; }
        public bool IsNeedsCleaningLocation { get; set; }

        public bool IsFlowerEnabled { get; set; }
        public bool IsVanillaBeanEndabled { get; set; }
        public int VanillaBeansCount { get; set; }
        public bool DidPestsAttacked { get; set; }
        public bool DidDiseasesAppeared { get; set; }
        public DateTime DueDate { get; set; }
    }
}
