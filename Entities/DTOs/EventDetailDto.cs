using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EventDetailDto:IDto
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string DestinationName { get; set; }
        public string CountryName { get; set; }
        public string CarName { get; set; }

    }
}
