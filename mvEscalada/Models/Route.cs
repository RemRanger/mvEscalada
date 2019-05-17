using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvEscalada.Models
{
    public class Route
    {
        public long Id { get; set; }
        public string Color{ get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Rating { get; set; }
        public string Sublocation { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateUntil { get; set; }
        public int? Result { get; set; }
        public decimal? Percentage { get; set; }

    }
}
