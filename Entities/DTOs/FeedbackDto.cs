using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class FeedbackDto : IDto
    {
        public string AttendeeName { get; set; }
        public string CarName { get; set; }

        public string Comment { get; set; }
        public double Rating { get; set; }
    }
}
