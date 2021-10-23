using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Destination:IEntity
    {
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
        public int CountryId { get; set; }
    }
}
