using Core.DataAccess;
using Core.Entities.Concrete;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IAttendeeDal:IEntityRepository<Attendee>
    {
        List<OperationClaim> GetClaims(Attendee attendee);

    }
}
