using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDestinationService
    {
        IDataResult<List<Destination>> GetAll();
        IDataResult<Destination> GetByDestinationId(int id);
        IResult Add(Destination destination);
        IResult Delete(Destination destination);
        IResult Update(Destination destination);

        IDataResult<List<Destination>> GetDestinationByCountryId(int id);
        IDataResult<List<Destination>> GetDestinationByCountry(Country country);

        IResult DeleteByDestinationName(string destinationName);

        IDataResult<Destination> GetByDestinationName(string destinationName);
    }
}
