using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        IDataResult<List<Photo>> GetAll();
        IDataResult<Photo> GetById(int id);
        IResult Add(Photo photo);
        IResult Delete(Photo photo);
        IResult Update(Photo photo);

        IDataResult<List<Photo>> GetPhotosByCarId(int carId);


    }
}
