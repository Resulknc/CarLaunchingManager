using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {

        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByEmail(string Email);
        IDataResult<User> GetById(int Id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        

        IResult DeleteByUsername(string username);

        IDataResult<User> GetByUsername(string username);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
