using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAttendeePhotoService
    {

        IDataResult<List<AttendeePhoto>> GetAll();
        IDataResult<AttendeePhoto> GetById(int id);
        IResult Add(AttendeePhoto photo);
        IResult Delete(AttendeePhoto photo);
        IResult Update(AttendeePhoto photo);

        IDataResult<List<AttendeePhoto>> GetPhotosByAttendeeId(int attendeeId);
    }
}
