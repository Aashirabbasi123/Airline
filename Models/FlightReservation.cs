using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline_reservation.Models
{
    [Table("TblFlightReservation")]
    public class FlightReservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "From")]
        public string ResFrom { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "To")]
        public string ResTo { get; set; }

        [Required]
        [Display(Name = "Departure Date")]
        public DateTime ResDepDate { get; set; }

        [Required]
        [Display(Name = "Departure Time")]
        public TimeSpan ResTime { get; set; }

        [Display(Name = "Return Date")]
        public DateTime? ResReturnDate { get; set; }

        [Display(Name = "Return Time")]
        public TimeSpan? ResReturnTime { get; set; }

        [Required]
        [Display(Name = "Trip Type")]
        public string TripType { get; set; }

        [Required]
        [Display(Name = "Ticket Price")]
        public decimal ResTicketPrice { get; set; }

        [Required]
        [ForeignKey("AeroplaneInfo")]
        public int Planeid { get; set; }

        public virtual AeroplaneInfo AeroplaneInfo { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Seat Type")]
        public string SeatType { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Plane Registration")]
        public string ResPlane { get; set; }
    }
}
