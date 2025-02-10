using System;
using SQLite;

namespace Zeving.Models
{
    public class TaskTuteur
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int DelayDay { get; set; }
        public int DelayTrigger { get; set; }
        public bool Toremove { get; set; }
        public string NameOfGeographicPosition { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public string TuteurLocation { get; set; }

        public bool IsAddCompost { get; set; }
        public bool IsAddSlugKiller { get; set; }
        public bool IsNeedsHealling { get; set; }
        public bool IsNeedsFeeding { get; set; }
        public bool IsNeedsCleaningLocation { get; set; }

        public bool IsFlowerEnabled { get; set; }
        public bool IsVanillaBeanEnabled { get; set; }
        public int VanillaBeansCount { get; set; }
        public bool DidPestsAttacked { get; set; }
        public bool DidDiseasesAppeared { get; set; }


        public bool IsAddCompostDone { get; set; }
        public bool IsAddSlugKillerDone { get; set; }
        public bool IsNeedsHeallingDone { get; set; }
        public bool IsNeedsFeedingDone { get; set; }
        public bool IsNeedsCleaningLocationDone { get; set; }

        public bool IsFlowerEnabledDone { get; set; }
        public bool IsVanillaBeanEnabledDone { get; set; }
        public bool DidPestsAttackedDone { get; set; }
        public bool DidDiseasesAppearedDone { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsHidden { get; set; }

    }
}
