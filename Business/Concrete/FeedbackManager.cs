using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FeedbackManager : IFeedbackService
    {
        IFeedbackDal _feedbackDal;
        IEventService _eventService;

        public FeedbackManager(IFeedbackDal feedback, IEventService eventService)
        {
            _feedbackDal = feedback;
            _eventService = eventService;
        }

        public IResult Add(Feedback feedback)
        {
            feedback = CalculateAverage(feedback).Data;
            _feedbackDal.Add(feedback);

            List<Feedback> feedbacks = _feedbackDal.GetAll(f => f.EventId == feedback.EventId);

            double average = 0;

            foreach (var feed in feedbacks)
            {
                average += feed.AvaragePoint;
            }
            average = average / feedbacks.Count;

            UpdateEventRating(feedback, average);



            return new SuccessResult();

        }

        public IDataResult<List<Feedback>> GetAll()
        {
            return new SuccessDataResult<List<Feedback>>(_feedbackDal.GetAll());
        }

        public IDataResult<List<Feedback>> GetAllByEventId(int eventId)
        {
            return new SuccessDataResult<List<Feedback>>(_feedbackDal.GetAll(p => p.EventId == eventId));
        }

        public IResult Update(Feedback feedback)
        {
            var result = this.GetAllByEventId(feedback.EventId);
            if (result.Data == null)
            {
                _feedbackDal.Add(feedback);
                return new SuccessResult();
            }

            return new SuccessResult();
        }

        private IResult UpdateEventRating(Feedback feedback, double average)
        {
            Event selectedEvent = _eventService.GetByEventId(feedback.EventId).Data;
            selectedEvent.Rating = average;
            _eventService.Update(selectedEvent);

            return new SuccessResult();
        }


        private IDataResult<Feedback> CalculateAverage(Feedback feedback)
        {
            feedback.AvaragePoint = (feedback.CarPoint + feedback.EventPoint + feedback.LocationPoint) / 3;

            return new SuccessDataResult<Feedback>(feedback);
        }

    }

}
