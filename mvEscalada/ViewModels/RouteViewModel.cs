using mvEscalada.Models;
using System.Collections.Generic;

namespace mvEscalada.ViewModels
{
    public class RouteViewModel
    {
        public string Title { get; set; }
        public Location Location { get; set; }
        public List<Route> Routes { get; set; }
        public string Api { get; set; }
    }
}
