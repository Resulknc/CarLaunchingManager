using Entities.Concrete;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.DTOs;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfEventDal : EfEntityRepositoryBase<Event, CarLaunchingManagerContext>, IEventDal
    {
        public List<EventDetailDto> GetEventDto(int eventId)
        {
            using (CarLaunchingManagerContext context = new CarLaunchingManagerContext())
            {
                var result = from e in context.Events
                             join co in context.Countries on e.CountryId equals co.CountryId
                             join de in context.Destinations on e.DestinationId equals de.DestinationId
                             join ca in context.Cars on e.CarId equals ca.CarId
                             join inv in context.Intivees on e.EventId equals inv.EventId
                             where e.EventId == eventId
                             select new EventDetailDto
                             {
                                 EventId = e.EventId,
                                 Date = e.Date,
                                 DestinationName = de.DestinationName,
                                 CountryName = co.CountryName,
                                 CarName = ca.CarName
                             };
                return result.ToList();

            }
        }

        public List<EventDetailDto> GetEventsDtos()
        {
            using(CarLaunchingManagerContext context =new CarLaunchingManagerContext())
            {
                var result = from e in context.Events
                             join co in context.Countries on e.CountryId equals co.CountryId
                             join de in context.Destinations on e.DestinationId equals de.DestinationId
                             join ca in context.Cars on e.CarId equals ca.CarId
                             
                             select new EventDetailDto
                             {
                                 EventId = e.EventId,
                                 Date = e.Date,
                                 DestinationName = de.DestinationName,
                                 CountryName = co.CountryName,
                                 CarName = ca.CarName
                             };
                return result.ToList();

            }
        }

        
    }
}
