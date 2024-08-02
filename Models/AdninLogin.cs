using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline_reservation.Models
{
    [Table("TblAdminLogin")]
    public class AdninLogin
    {
        [Key]

        public int AdminId { get; set; }


        [Required(ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]

        public string AdName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Min 5 Char Req"), MaxLength(10, ErrorMessage = "Max 10 char allow")]

        public string Password { get; set; }
    }
}
