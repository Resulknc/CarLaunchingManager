using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Feedback:IEntity
    {
        public int FeedbackId { get; set; }
        public int EventId { get; set; }
        public double CarPoint { get; set; }
        public double EventPoint { get; set; }
        public double LocationPoint { get; set; }
        public double AvaragePoint { get; set; }
        public string Comment { get; set; }
        public int AttendeeId { get; set; }
    }
}
