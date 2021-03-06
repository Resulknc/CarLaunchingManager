using Business.Abstract;
using Business.Concrete;
using Core.Utilities.CloudinaryOperations;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Mailkit;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.Configure<MailkitSettings>(Configuration.GetSection("MailkitSettings"));

            services.AddCors();
            services.AddControllers();
           

            ////Events Controller
            //services.AddSingleton<IEventService, EventManager>();
            //services.AddSingleton<IEventDal, EfEventDal>();

            ////Attendees Controller
            //services.AddSingleton<IAttendeeService, AttendeeManager>();
            //services.AddSingleton<IAttendeeDal, EfAttendeeDal>();

            ////Users Controller
            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<IUserDal, EfUserDal>();

            ////Cars Controller
            //services.AddSingleton<ICarService, CarManager>();
            //services.AddSingleton<ICarDal, EfCarDal>();

            ////Photo Controller
            //services.AddSingleton<IPhotoService, PhotoManager>();
            //services.AddSingleton<IPhotoDal,EfPhotoDal>();

            ////Attendee Photo Controller
            //services.AddSingleton<IAttendeePhotoService, AttendeePhotoManager>();
            //services.AddSingleton<IAttendeePhotoDal, EfAttendeePhotoDal>();
            ////Cloudinary
            //services.AddScoped<ICloudinaryService, CloudinaryManager>();

            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<IUserDal, EfUserDal>();

            //services.AddSingleton<IAuthService, AuthManager>();
            //services.AddSingleton<ITokenHelper, JwtHelper>();




            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

            ////Destination Controller
            //services.AddSingleton<IDestinationService, DestinationManager>();
            //services.AddSingleton<IDestinationDal, EfDestinationDal>();

            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            //app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
            //app.UseCors(builder => builder.WithOrigins("http://localhost:4401").AllowAnyHeader());
            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
