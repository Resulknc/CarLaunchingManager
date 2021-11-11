using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEventDal:IEntityRepository<Event>
    {
        List<EventDto> GetEventsDtos();
        List<EventDto> GetEventDto(int eventId);
    }
}
