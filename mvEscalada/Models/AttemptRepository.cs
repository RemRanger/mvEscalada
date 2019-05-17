using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mvEscalada.Models
{
    public class AttemptRepository : IAttemptRepository
    {
        private List<Attempt> attempts = null;

        public async Task<IEnumerable<Attempt>> RetrieveAttemptsFromApi()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(GetAttemptsApi());
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();

            IEnumerable<Attempt> attempts = JsonConvert.DeserializeObject<IEnumerable<Attempt>>(json);

            return attempts;
        }

        public string GetAttemptsApi() => Utils.GetApiUrl("attempt", "read");

        public IEnumerable<Attempt> GetAttempts()
        {
            if (this.attempts == null)
                attempts = RetrieveAttemptsFromApi().Result.ToList();

            return this.attempts;
        }

        public Attempt GetAttemptById(long id)
        {
            return GetAttempts().FirstOrDefault(a => a.Id == id);
        }

    }
}
