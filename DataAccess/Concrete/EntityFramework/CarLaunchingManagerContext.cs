using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarLaunchingManagerContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarLaunchingManager;Trusted_Connection=true");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invitee> Intivees { get; set; }
    }
}
