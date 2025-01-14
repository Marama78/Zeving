using SQLite;
using Xamarin.Forms;

namespace Zeving.Models
{
    public class Inventory
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int LastCount {  get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public string SiteLocation { get; set; }
        public Image Image { get; set; }
    }
}
