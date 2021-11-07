using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IPhotoDal _photoDal;
        public CarManager(ICarDal carDal, IPhotoDal photoDal )
        {
            _carDal = carDal;
            _photoDal = photoDal;

        }
        public IResult Add(Car car)
        {
           _carDal.Add(car);
           return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(car => car.CarId == id));
        }

        public IDataResult<List<Photo>> GetPhotosByCarId(int id)
        {
            var carPhotos = _photoDal.GetAll(photo => photo.CarId == id);

            return new SuccessDataResult<List<Photo>>(carPhotos);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}