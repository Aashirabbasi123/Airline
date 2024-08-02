using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline_reservation.Models
{
    [Table("TblPlaneInfo")]
    public class AeroplaneInfo
    {
        [Key]

        public int PlaneId { get; set; }
        [Display(Name = "Areoplane Name")]
        [Required(ErrorMessage = "Areoplane Name Required")]
        [MaxLength(30, ErrorMessage = "Max 30 char allow"), MinLength(3, ErrorMessage = "Min 3 Char Req")]

        public string APlaneName { get; set; }

        [Display(Name = "Seating Capacity")]
        [Required(ErrorMessage = "Seating Capacity reqried")]
        public int SeatingCapacity { get; set; }

        [Required(ErrorMessage = "Price reqried")]
        public float Price { get; set; }

    }
}
