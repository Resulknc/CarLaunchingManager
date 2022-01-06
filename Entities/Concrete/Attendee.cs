using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Attendee:IEntity
    {
        public int AttendeeId { get; set; }
        public string AttendeeName { get; set; }
        public string AttendeeJob { get; set; }
        public string AttendeeNationality { get; set; }
        public string AttendeeEmail { get; set; }
        public byte[] AttendeePasswordHash { get; set; }
        public byte[] AttendeePasswordSalt { get; set; }

        public List<AttendeePhoto> AttendeePhotos { get; set; }

        public Attendee()
        {
            AttendeePhotos = new List<AttendeePhoto>();
        }
    }
}
