using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline_reservation.Models
{
    [Table("TblFlihtReservation")]
    public class FlightReservation
    {
        [Key]

        public int Resid { get; set; }

        [Required(ErrorMessage = "Form City req")]
        [Display(Name = "From City")]
        [StringLength(40, ErrorMessage = "Max 40 char allowed")]

        public string ResFrom { get; set; }

        [Required(ErrorMessage = "To City req")]
        [Display(Name = "To City")]
        [StringLength(40, ErrorMessage = "Max 40 char allowed")]

        public string ResTo { get; set; }

        [Display(Name = "Departure Date")]
        [DataType(DataType.Date)]

        public string ResDepDate { get; set; }

        [Display(Name = "Departure Time")]
        [DataType(DataType.Time)]

        public string ResTime { get; set; }

        public int PlaneId { get; set; }
        public virtual AeroplaneInfo PlaneInfo { get; set; }


        [Required, Display(Name = "Seat Available")]
        public string SeatType { get; set; }

        [Required,Display(Name ="Price")]

        public float ResTicketPrice { get; set; }

        [Required ,Display(Name = "Plane")]

        public string ResPlane {  get; set; }
        public virtual ICollection<FlightBooking> TblFlightBooking { get; set; }
    }
}
