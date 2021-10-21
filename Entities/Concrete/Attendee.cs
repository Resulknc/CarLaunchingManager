using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Attendee : IEntity
    {
        public int InviteeId { get; set; }
        public int AttendeeId { get; set; }
        public int EventId { get; set; }
    }
}
