using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvEscalada.Models
{
    public interface IRouteRepository
    {
        IEnumerable<Route> GetRoutes(long locationid);
        string GetRoutesApi(long locationId);
    }
}
