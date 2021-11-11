using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfInviteeDal:EfEntityRepositoryBase<Invitee,CarLaunchingManagerContext>,IInviteeDal
    {
        public List<InviteesDto> GetEventDto(int eventId)
        {
            using (CarLaunchingManagerContext context = new CarLaunchingManagerContext())
            {
                var result = from invitee in context.Intivees
                             join att in context.Attendees on invitee.AttendeeId equals att.AttendeeId
                             where invitee.EventId == eventId
                             select new InviteesDto
                             {
                                 AttendeeId = att.AttendeeId,
                                 AttendeeName = att.AttendeeName,
                                 AttendeeJob = att.AttendeeJob,
                                 AttendeeNationality = att.AttendeeNationality,
                             };
                return result.ToList();

            }
        }
    }
}
