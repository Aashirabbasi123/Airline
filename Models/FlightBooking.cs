using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline_reservation.Models
{
    [Table("TblFlightBook")]
    public class FlightBooking
    {
        [Key]
        public int BokId { get; set; }

        [Required, Display(Name = "Customer Name")]
        public string BokCusName { get; set; }

        [Required, Display(Name = "Customer Address")]
        public string BokCusAddress { get; set; }

        [Required, Display(Name = "Customer Email")]
        public string BokCusEmail { get; set; }

        [Required, Display(Name = "No Of Seats")]
        public int BokCusSeat { get; set; }

        [Required, Display(Name = "Phone Numer")]
        public string BokCusPhone { get; set; }

        [Required, Display(Name = "Customer CNIC")]
        public string  BokCusNic { get; set; }

        public int ResId { get; set; }

        public virtual FlightReservation FlightReservation { get; set; }

    }
}
