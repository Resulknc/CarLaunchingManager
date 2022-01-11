using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EventDto:IDto
    {
        public int EventId { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; }
        public string DestinationName { get; set; }
        public string CountryName { get; set; }
        public string CarName { get; set; }
        public double Rating { get; set; }

    }
}
