using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.CloudinaryOperations;
using Core.Utilities.Mailkit;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Events Controller
            builder.RegisterType<EventManager>().As<IEventService>().SingleInstance();
            builder.RegisterType<EfEventDal>().As<IEventDal>().SingleInstance();

            //Attendees Controller
            builder.RegisterType<AttendeeManager>().As<IAttendeeService>().SingleInstance();
            builder.RegisterType<EfAttendeeDal>().As<IAttendeeDal>().SingleInstance();

            //Destination Controller
            builder.RegisterType<EfDestinationDal>().As<IDestinationDal>().SingleInstance();
            builder.RegisterType<DestinationManager>().As<IDestinationService>().SingleInstance();

            //Country Controller
            builder.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();
            builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            //Users Controller
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();


            //Cars Controller
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            //Photo Controller
            builder.RegisterType<PhotoManager>().As<IPhotoService>().SingleInstance();
            builder.RegisterType<EfPhotoDal>().As<IPhotoDal>().SingleInstance();

            //Attendee Photo Controller
            builder.RegisterType<EfAttendeePhotoDal>().As<IAttendeePhotoDal>().SingleInstance();
            builder.RegisterType<AttendeePhotoManager>().As<IAttendeePhotoService>().SingleInstance();

            //Invitee Controller
            builder.RegisterType<EfInviteeDal>().As<IInviteeDal>().SingleInstance();
            builder.RegisterType<InviteeManager>().As<IInviteeService>().SingleInstance();

            //Cloudinary
            builder.RegisterType<CloudinaryManager>().As<ICloudinaryService>().SingleInstance();
            
            //Point Controller
            builder.RegisterType<FeedbackManager>().As<IFeedbackService>().SingleInstance();
            builder.RegisterType<EfFeedbackDal>().As<IFeedbackDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<AuthAttendeeManager>().As<IAuthAttendeeService>().SingleInstance();


            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            //builder.RegisterType<MailkitManager>().As<IMailkitService>().SingleInstance();
            builder.RegisterType<MailManager>().As<IMailService>().SingleInstance();

        
        }
    }
}
