using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Attendee : IEntity
    {
        public int AttendeeId { get; set; }
        public string AttendeeName { get; set; }
        public string AttendeeJob { get; set; }
        public string AttendeeNationality { get; set; }

        public List<AttendeePhoto> AttendeePhotos { get; set; }

        public Attendee()
        {
            AttendeePhotos = new List<AttendeePhoto>();
        }
    }

}
