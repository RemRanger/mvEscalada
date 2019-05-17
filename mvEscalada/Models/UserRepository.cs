using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mvEscalada.Models
{
    public class UserRepository : IUserRepository
    {
        private List<User> Users = null;

        public async Task<IEnumerable<User>> RetrieveUsersFromApi()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(GetUsersApi());
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();

            IEnumerable<User> Users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);

            return Users;
        }

        public string GetUsersApi() => Utils.GetApiUrl("user", "read");

        public IEnumerable<User> GetUsers()
        {
            if (this.Users == null)
                Users = RetrieveUsersFromApi().Result.ToList();

            return this.Users;
        }

        public User GetUserById(long id)
        {
            return GetUsers().FirstOrDefault(l => l.Id == id);
        }

    }
}
