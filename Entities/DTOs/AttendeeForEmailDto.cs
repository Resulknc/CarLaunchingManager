using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AttendeeForEmailDto : IDto
    {
        public string Email { get; set; }
        public string AttendeeName { get; set; }
    }
}
