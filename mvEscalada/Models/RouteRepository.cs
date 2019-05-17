using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mvEscalada.Models
{
    public class RouteRepository : IRouteRepository
    {
        private List<Route> Routes = null;

        public async Task<IEnumerable<Route>> RetrieveRoutesFromApi(long locationId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(GetRoutesApi(locationId));
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();

            IEnumerable<Route> Routes = JsonConvert.DeserializeObject<IEnumerable<Route>>(json);

            return Routes;
        }

        public string GetRoutesApi(long locationId) => $"{Utils.GetApiUrl("route", "read")}?locationId={locationId}";

        public IEnumerable<Route> GetRoutes(long locationId)
        {
            if (this.Routes == null)
                Routes = RetrieveRoutesFromApi(locationId).Result.Where(r => !r.DateUntil.HasValue || r.DateUntil.Value >= DateTime.Now).ToList();

            return this.Routes;
        }
    }
}
