using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthAttendeeService
    {
        IDataResult<Attendee> Register(AttendeeForRegisterDto attendeeForRegisterDto);
        IDataResult<Attendee> Login(AttendeeForLoginDto attendeeForLoginDto);
        IResult AttendeeExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Attendee attendee);
    }
}
