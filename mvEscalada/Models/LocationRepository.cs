using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvEscalada.Models
{
    public class LocationRepository : ILocationRepository
    {
        private List<Location> locations = new List<Location>
        {
            new Location {Id = 1, Name = "Klimhal Bommeleskonte", WebsiteUrl = "www.klimhalbommeleskonte.nl"},
            new Location {Id = 2, Name = "Boulderhal Zuurstof", WebsiteUrl = "www.boulderhalzuurstof.nl"},
            new Location {Id = 3, Name = "Compact Boulderhal", WebsiteUrl = "www.compactboulderhal.nl"}
        };

        public IEnumerable<Location> GetLocations()
        {
            return this.locations;
        }

        public Location GetLocationById(long id)
        {
            return locations.FirstOrDefault(l => l.Id == id);
        }

    }
}
