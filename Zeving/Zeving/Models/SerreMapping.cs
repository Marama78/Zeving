
using System;
using System.Collections.Generic;
using System.Text;

namespace Zeving.Models
{
    public class SerreMapping
    {
        public string Tcode { get; set; }
        public TaskTuteur TaskTuteur { get; set; }
        public bool HasTask { get; set; }
    }
}
