
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class InviteeManager : IInviteeService
    {
        IInviteeDal _inviteeDal;

        public InviteeManager(IInviteeDal inviteeDal)
        {
            _inviteeDal = inviteeDal;
        }

        public IResult Add(Invitee invitee)
        {
            _inviteeDal.Add(invitee);
            return new SuccessResult();
        }

        public IResult Delete(Invitee invitee)
        {
            _inviteeDal.Delete(invitee);
            return new SuccessResult();
        }

        public IDataResult<List<Invitee>> GetAll()
        {
            return new SuccessDataResult<List<Invitee>>(_inviteeDal.GetAll());
        }

        public IDataResult<Invitee> GetByInviteeId(int id)
        {
            return new SuccessDataResult<Invitee>(_inviteeDal.Get(i => i.InviteeId == id));
        }

        public IResult Update(Invitee invitee)
        {
            _inviteeDal.Update(invitee);
            return new SuccessResult();
        }
    }
}
