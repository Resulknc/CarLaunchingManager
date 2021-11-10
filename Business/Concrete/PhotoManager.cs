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
    public class PhotoManager : IPhotoService
    {
        private readonly IPhotoDal _photoDal;

        public PhotoManager(IPhotoDal photoDal)
        {
            _photoDal = photoDal;
        }

        public IResult Add(Photo photo)
        {
            _photoDal.Add(photo);
            return new SuccessResult();
        }

        public IResult Delete(Photo photo)
        {
            _photoDal.Delete(photo);
            
            return new SuccessResult();
        }

        public IDataResult<List<Photo>> GetAll()
        {
            return new SuccessDataResult<List<Photo>>(_photoDal.GetAll());
        }



        public IDataResult<Photo> GetById(int id)
        {
            return new SuccessDataResult<Photo>(_photoDal.Get(photo => photo.PhotoId == id));
        }

        public IDataResult<List<Photo>> GetPhotosByCarId(int carId)
        {
            return new SuccessDataResult<List<Photo>>(_photoDal.GetAll(photo=>photo.CarId==carId));
        }

        public IResult Update(Photo photo)
        {
            _photoDal.Update(photo);
            return new SuccessResult();
        }
    }
}
