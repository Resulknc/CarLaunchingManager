using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EventDetail : IEntity
    {
        //    eventId:number;
        //carName:string;
        //date:string;
        //countryName:string;
        //destinationName:string;
        public int EventId { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; }
        public string Country { get; set; }
        public string Destination { get; set; }

    }
}
