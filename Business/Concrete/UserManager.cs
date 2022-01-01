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

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == Id));
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

        public IResult DeleteByUsername(string username)
        {
            var user = _userDal.Get(user => user.UserName == username);
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

        public IDataResult<User> GetByUsername(string username)
        {
            return new SuccessDataResult<User>(_userDal.Get(user => user.UserName == username));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new SuccessResult();
        }

    }
}