using mvEscalada.Models;
using System.Collections.Generic;

namespace mvEscalada.ViewModels
{
    public class LocationViewModel
    {
        public string Title { get; set; }
        public List<Location> Locations { get; set; }
        public string Api { get; set; }

    }
}
