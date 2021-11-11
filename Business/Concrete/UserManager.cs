using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;

        }
        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult();
        }

     

        public IResult Delete(User user)
        {
            _userDal.Delete(user);

            return new SuccessResult();

        }

     

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByEmail(string Email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == Email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new SuccessResult();
        }

    }
}