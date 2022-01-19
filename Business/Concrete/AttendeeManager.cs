using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AttendeeManager : IAttendeeService
    {
        IAttendeeDal _attendeeDal;
        public AttendeeManager(IAttendeeDal attendeeDal)
        {
            _attendeeDal = attendeeDal;
        }
        
        public IResult Add(Attendee attendee)
        {
            _attendeeDal.Add(attendee);
            return new SuccessResult();
        }

        public IResult Delete(Attendee attendee)
        {
            _attendeeDal.Delete(attendee);
            return new SuccessResult();
        }

        public IDataResult<List<Attendee>> GetAll()
        {
            return new SuccessDataResult<List<Attendee>>(_attendeeDal.GetAll());           
        }

        public IDataResult<Attendee> GetByAttendeeId(int id)
        {
            return new SuccessDataResult<Attendee>(_attendeeDal.Get(p => p.AttendeeId == id));
        }
        public IDataResult<List<OperationClaim>> GetClaims(Attendee attendee)
        {
            return new SuccessDataResult<List<OperationClaim>>(_attendeeDal.GetClaims(attendee));
        }
        public IDataResult<Attendee> GetByEmail(string Email)
        {
            return new SuccessDataResult<Attendee>(_attendeeDal.Get(p => p.AttendeeEmail == Email));
        }
        public IResult Update(Attendee attendee)
        {
            _attendeeDal.Update(attendee);
            return new SuccessResult();
        }

        

    }
}
