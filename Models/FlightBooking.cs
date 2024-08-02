using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline_reservation.Models
{
    [Table("TblFlightBook")]
    public class FlightBooking
    {
        [Key]

        public int bid { get; set; }

        [Required(ErrorMessage = "Form City req")]
        [Display(Name = "From City")]
        [StringLength(40, ErrorMessage = "Max 40 char allowed")]

        public string From { get; set; }

        [Required(ErrorMessage = "To City req")]
        [Display(Name = "To City")]
        [StringLength(40, ErrorMessage = "Max 40 char allowed")]

        public string To { get; set; }

        [Display(Name = "Departure Date")]
        [DataType(DataType.Date)]

        public string DDate { get; set; }

        [Display(Name = "Departure Time")]
        [DataType(DataType.Time)]

        public string DTime { get; set; }

        public int PlaneId { get; set; }
        public virtual AeroplaneInfo PlaneInfo { get; set; }


        [Display(Name = "Seat Type")]
        [StringLength(25)]
        public string SeatType { get; set; }
    }
}
