using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AttendeeForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string AttendeeName { get; set; }
        public string Password { get; set; }
        public string AttendeeJob { get; set; }
        public string AttendeeNationality { get; set; }


    }
}
