using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IInviteeService
    {
        IDataResult<List<Invitee>> GetAll();
        IDataResult<Invitee> GetByInviteeId(int id);
        IResult Add(Invitee invitee);
        IResult Delete(Invitee invitee);
        IResult Update(Invitee invitee);

        IResult DeleteByEventAndAttenedeeId(int eventId, int attendeeId);
        IDataResult<List<Invitee>> GetInviteesByEventId(int eventId);
    }
}