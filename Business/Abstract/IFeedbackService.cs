using Core.Utilities.Results;
using Entities.Concrete;
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
        IDataResult<Feedback> GetAllByEventId(int eventId);
        IDataResult<List<Feedback>> GetAll();

    }
}
