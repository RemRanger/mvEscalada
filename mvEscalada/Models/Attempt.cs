using System;
using System.Collections.Generic;

namespace mvEscalada.Models
{
    public class Attempt
    {
        public long Id { get; set; }
        public int? Result { get; set; }
        public decimal? Percentage { get; set; }
        public string Comment { get; set; }
        public long RouteId { get; set; }
        public string RouteColor { get; set; }
        public string RouteName { get; set; }
        public string RouteType { get; set; }
        public string RouteRating { get; set; }
        public string RouteSublocation { get; set; }
        public DateTime? RouteDateUntil { get; set; }
        public string RoutePictureFileName { get; set; }
        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public long SessionId { get; set; }
        public DateTime SessionDate { get; set; }
        public long UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }

    public class AttemptGroup
    {
        public long SessionId { get; set; }
        public long UserId { get; set; }
        public List<Attempt> Attempts { get; set; }
    }
}
