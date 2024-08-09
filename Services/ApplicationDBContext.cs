using Airline_reservation.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline_reservation.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) :base (options)
        {
        }

        public DbSet<AdninLogin> AdminLogins { get; set; }
        public DbSet<UserLogin> UserAccouunts { get; set; }

        public DbSet<AeroplaneInfo> Planeinfo { get; set; }
        public DbSet<FlightBooking> FlightBookings { get; set; }
        public DbSet<FlightReservation> FlightReservation { get; set; }

    }
}
