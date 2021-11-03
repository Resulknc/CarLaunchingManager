using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Event : IEntity
    {
        public int EventId { get; set; }
        public int CarId { get; set; }
        public int DestinationId { get; set; }
        public int CountryId { get; set; }
        public DateTime Date { get; set; }
    }
}
