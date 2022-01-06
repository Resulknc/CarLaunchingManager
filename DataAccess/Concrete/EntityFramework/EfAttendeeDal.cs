using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAttendeeDal : EfEntityRepositoryBase<Attendee, CarLaunchingManagerContext>, IAttendeeDal
    {
        public List<OperationClaim> GetClaims(Attendee attendee)
        {
            using (var context = new CarLaunchingManagerContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join attendeeOperationClaim in context.AttendeeOperationClaims
                                 on operationClaim.Id equals attendeeOperationClaim.OperationClaimId
                             where attendeeOperationClaim.AttendeeId == attendee.AttendeeId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
