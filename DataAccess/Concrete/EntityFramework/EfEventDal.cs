using Entities.Concrete;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEventDal: EfEntityRepositoryBase<Event,CarLaunchingManagerContext>,IEventDal
    {
    }
}
