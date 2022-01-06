using Core.Utilities.Results;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAttendeeService
    {
        IDataResult<List<Attendee>> GetAll();
        IDataResult<Attendee> GetByAttendeeId(int id);
        IDataResult<Attendee> GetByEmail(string Email);
        IResult Add(Attendee attendee);
        IResult Delete(Attendee attendee);
        IResult Update(Attendee attendee);
    }
}
