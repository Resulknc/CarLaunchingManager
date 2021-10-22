using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Attendee : IEntity
    {
        public int AttendeeId { get; set; }
        public string AttendeName { get; set; }
        public string AttendeeJob { get; set; }
        public string AttendeeNationality { get; set; }
    }
}
