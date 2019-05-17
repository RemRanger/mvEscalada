using mvEscalada.Models;
using System.Collections.Generic;

namespace mvEscalada.ViewModels
{
    public class UserViewModel
    {
        public string Title { get; set; }
        public List<User> Users { get; set; }
        public string Api { get; set; }
    }
}
