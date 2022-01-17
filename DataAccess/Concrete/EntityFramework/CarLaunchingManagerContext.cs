using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarLaunchingManagerContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Launchfy;Trusted_Connection=true");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invitee> Invitees { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<AttendeePhoto> AttendeePhotos { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<AttendeeOperationClaim> AttendeeOperationClaims { get; set; }

    }
}
