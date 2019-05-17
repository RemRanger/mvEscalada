using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mvEscalada.Models
{
    public class LocationRepository : ILocationRepository
    {
        private List<Location> locations = null;

        public async Task<IEnumerable<Location>> RetrieveLocationsFromApi()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(GetLocationsApi());
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();

            IEnumerable<Location> locations = JsonConvert.DeserializeObject<IEnumerable<Location>>(json);

            return locations;
        }

        public string GetLocationsApi() => "https://www.remranger.com/escalada-api/location-read.php";

        public IEnumerable<Location> GetLocations()
        {
            if (this.locations == null)
                locations = RetrieveLocationsFromApi().Result.ToList();

            return this.locations;
        }

        public Location GetLocationById(long id)
        {
            return GetLocations().FirstOrDefault(l => l.Id == id);
        }

    }
}
