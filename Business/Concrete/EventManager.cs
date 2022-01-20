using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
        ICountryService _countryService;
        IDestinationService _destinationService;
        ICarService _carService;
        public EventManager(IEventDal eventDal,ICountryService countryService,IDestinationService destinationService)
        {
            _eventDal = eventDal;
            _countryService = countryService;
            _destinationService = destinationService;
        }

        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(EventValidator))]
        public IResult Add(EventDetail launch)
        {
            var ev = CreateEvent(launch);
            _eventDal.Add(ev.Data);
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

        public IDataResult<List<EventDto>> GetEventsOfAttendee(int attendeId)
        {
            return new SuccessDataResult<List<EventDto>>(_eventDal.GetEventOfAttendee(attendeId));
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


        private IDataResult<Event> CreateEvent(EventDetail eventDetail)
        {
            var country = _countryService.GetByCountryName(eventDetail.Country);
            //var car = _carService.GetCarByModel(eventDetail.CarName);
            var destination = _destinationService.GetByDestinationName(eventDetail.Destination);

            return new SuccessDataResult<Event>(new Event {EventId=eventDetail.EventId,CarId=eventDetail.CarId,
                CountryId=country.Data.CountryId,Date=eventDetail.Date,DestinationId=destination.Data.DestinationId,Rating=0 });
        }
       
    }
}
