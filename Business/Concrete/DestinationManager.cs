
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }
        public IResult Add(Destination destination)
        {
            _destinationDal.Add(destination);
            return new SuccessResult();
        }

        public IResult Delete(Destination destination)
        {
            _destinationDal.Delete(destination);
            return new SuccessResult();
        }

        public IDataResult<List<Destination>> GetAll()
        {
            return new SuccessDataResult<List<Destination>>(_destinationDal.GetAll());
        }

        public IDataResult<Destination> GetByDestinationId(int id)
        {
            return new SuccessDataResult<Destination>(_destinationDal.Get(d => d.DestinationId == id));
        }

        public IDataResult<List<Destination>> GetDestinationByCountry(Country country)
        {
            return new SuccessDataResult<List<Destination>>(_destinationDal.GetAll(destination => destination.CountryId == country.CountryId));
        }

        public IDataResult<List<Destination>> GetDestinationByCountryId(int id)
        {
            return new SuccessDataResult<List<Destination>>(_destinationDal.GetAll(destination => destination.CountryId==id));
        }

        public IResult Update(Destination destination)
        {
            _destinationDal.Update(destination);
            return new SuccessResult();
        }
    }
}
