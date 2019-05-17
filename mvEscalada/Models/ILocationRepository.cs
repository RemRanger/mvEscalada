using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvEscalada.Models
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetLocations();
        string GetLocationsApi();
        Location GetLocationById(long id);
    }
}
