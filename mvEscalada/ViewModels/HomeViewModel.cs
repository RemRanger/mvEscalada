using mvEscalada.Models;
using System.Collections.Generic;

namespace mvEscalada.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<AttemptGroup> AttemptGroups { get; set; }
        public string Api { get; set; }

    }
}
