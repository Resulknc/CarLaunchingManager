using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFeedbackDal : EfEntityRepositoryBase<Feedback, CarLaunchingManagerContext>, IFeedbackDal
    {
        public List<FeedbackDto> GetFeedbackDtos()
        {
            using (CarLaunchingManagerContext context = new CarLaunchingManagerContext())
            {
                var result = from e in context.Events
                             join ca in context.Cars on e.CarId equals ca.CarId
                             join f in context.Feedback on e.EventId equals f.EventId
                             join a in context.Attendees on f.AttendeeId equals a.AttendeeId

                             //join po in context.Feedback on e.EventId equals po.EventId

                             select new FeedbackDto
                             {
                                 AttendeeName = a.AttendeeName,
                                 CarName = ca.CarName,
                                 Comment = f.Comment,
                                 Rating = f.AvaragePoint
                             };
                return result.ToList();

            }
        }
    }
}
