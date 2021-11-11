using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EventManager : IEventService
    {
        IEventDal _eventDal;
        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }
        public IResult Add(Event launch)
        {
            _eventDal.Add(launch);
            return new SuccessResult();
        }

        public IResult Delete(Event launch)
        {
            _eventDal.Delete(launch);
            return new SuccessResult();
        }

        public IDataResult<List<Event>> GetAll()
        {
            return new SuccessDataResult<List<Event>>(_eventDal.GetAll());
        }

        public IDataResult<List<Event>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<Event>>(_eventDal.GetAll(p=> p.CarId==id));
        }

        public IDataResult<List<Event>> GetByCountryId(int id)
        {
            return new SuccessDataResult<List<Event>>(_eventDal.GetAll(p => p.CountryId == id));
        }

        public IDataResult<List<Event>> GetByDestinationId(int id)
        {
            return new SuccessDataResult<List<Event>>(_eventDal.GetAll(p => p.DestinationId == id));
        }

        public IDataResult<Event> GetByEventId(int id)
        {
            return new SuccessDataResult<Event>(_eventDal.Get(p => p.EventId == id));

        }


        public IDataResult<List<EventDto>> GetEventDto(int eventid)
        {
            return new SuccessDataResult<List<EventDto>>(_eventDal.GetEventDto(eventid));
        }

        public IDataResult<List<EventDto>> GetEventsDtos()
        {
            return new SuccessDataResult<List<EventDto>>(_eventDal.GetEventsDtos());
        }

        public IResult Update(Event launch)
        {
            _eventDal.Update(launch);
            return new SuccessResult();
        }

       
    }
}
