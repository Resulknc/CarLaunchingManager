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
        IResult Add(Photo user);
        IResult Delete(Photo user);
        IResult Update(Photo user);


    }
}
