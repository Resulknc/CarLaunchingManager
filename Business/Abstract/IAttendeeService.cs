using Core.Utilities.Results;
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
        IResult Add(Attendee attendee);
        IResult Delete(Attendee attendee);
        IResult Update(Attendee attendee);
    }
}
