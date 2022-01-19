using Business.Abstract;
using Business.Constants;
using Business.Utilities.Security.JWT;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthAttendeeManager : IAuthAttendeeService
    {
        private IAttendeeService _attendeeService;
        private ITokenHelperAttendee _tokenHelper;

        public AuthAttendeeManager(IAttendeeService attendeeService,ITokenHelperAttendee tokenHelper)
        {
            _attendeeService = attendeeService;
            _tokenHelper = tokenHelper;
        }

      
        public IDataResult<Attendee> Login(AttendeeForLoginDto attendeeForLoginDto)
        {
            var attendeeToCheck = _attendeeService.GetByEmail(attendeeForLoginDto.Email).Data;
            if (attendeeToCheck == null)
            {
                return new ErrorDataResult<Attendee>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(attendeeForLoginDto.Password, attendeeToCheck.AttendeePasswordHash, attendeeToCheck.AttendeePasswordSalt))
            {
                return new ErrorDataResult<Attendee>(Messages.PasswordError);
            }

            return new SuccessDataResult<Attendee>(attendeeToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<Attendee> Register(AttendeeForRegisterDto attendeeForRegisterDto)
        {

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(attendeeForRegisterDto.Password, out passwordHash, out passwordSalt);
            var attendee = new Attendee
            {
                AttendeeNationality= attendeeForRegisterDto.AttendeeNationality,
                AttendeeEmail = attendeeForRegisterDto.Email,
                AttendeeJob= attendeeForRegisterDto.AttendeeJob,
                AttendeePasswordHash = passwordHash,
                AttendeePasswordSalt = passwordSalt,
                AttendeeName = attendeeForRegisterDto.AttendeeName,
            };
            _attendeeService.Add(attendee);
            return new SuccessDataResult<Attendee>(attendee, Messages.AttendeeRegistered);

        }

        public IResult AttendeeExists(string email)
        {
            if (_attendeeService.GetByEmail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Attendee attendee)
        {
            var claims = _attendeeService.GetClaims(attendee).Data;
            var accessToken = _tokenHelper.CreateToken(attendee, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
