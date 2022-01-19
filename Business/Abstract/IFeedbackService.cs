using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeedbackService
    {
        IResult Add(Feedback point);
        IResult Update(Feedback point);
        IDataResult<List<Feedback>> GetAllByEventId(int eventId);
        IDataResult<List<Feedback>> GetAll();

        IDataResult<List<FeedbackDto>> GetFeedbackDtos();

    }
}
