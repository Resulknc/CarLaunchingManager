using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class AttendeePhotoManager : IAttendeePhotoService
    {
        private readonly IAttendeePhotoDal _attendeePhotoDal;

        public AttendeePhotoManager(IAttendeePhotoDal attendeePhotoDal)
        {
            _attendeePhotoDal = attendeePhotoDal;
        }

        public IResult Add(AttendeePhoto photo)
        {
            _attendeePhotoDal.Add(photo);
            return new SuccessResult();
        }

        public IResult Delete(AttendeePhoto photo)
        {
            _attendeePhotoDal.Delete(photo);
            return new SuccessResult();
        }

        public IDataResult<List<AttendeePhoto>> GetAll()
        {
            return new SuccessDataResult<List<AttendeePhoto>>(_attendeePhotoDal.GetAll());
        }

        public IDataResult<AttendeePhoto> GetById(int id)
        {
            return new SuccessDataResult<AttendeePhoto>(_attendeePhotoDal.Get(photo => photo.PhotoId == id));
        }

        public IDataResult<List<AttendeePhoto>> GetPhotosByAttendeeId(int attendeeId)
        {
            return new SuccessDataResult<List<AttendeePhoto>>(_attendeePhotoDal.GetAll(photo => photo.AttendeeId == attendeeId));
        }

        public IResult Update(AttendeePhoto photo)
        {
            _attendeePhotoDal.Update(photo);
            return new SuccessResult();
        }
    }
}
