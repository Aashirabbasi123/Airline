using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline_reservation.Models
{
    [Table("TblUserLogin")]
    public class UserLogin
    {
        [Key]

        public int UserId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required")]
        [MaxLength(40, ErrorMessage = "Max 40 char allow"), MinLength(3, ErrorMessage = "Min 3 Char Req")]

        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        [MaxLength(40, ErrorMessage = "Max 40 char allow"), MinLength(3, ErrorMessage = "Min 3 Char Req")]

        public string LastName { get; set; }


        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name Required")]
        [MaxLength(40, ErrorMessage = "Max 40 char allow"), MinLength(3, ErrorMessage = "Min 3 Char Req")]

        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [MaxLength(30, ErrorMessage = "Max 30 char allow"), MinLength(5, ErrorMessage = "Min 5 Char Req")]
        [DataType(DataType.EmailAddress)]

        public string EmaiL { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        [MaxLength(10, ErrorMessage = "Max 10 char allow"), MinLength(5, ErrorMessage = "Min 5 Char Req")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        [MaxLength(10, ErrorMessage = "Max 10 char allow"), MinLength(5, ErrorMessage = "Min 5 Char Req")]
        [DataType(DataType.Password)]

        public string CPassword { get; set; }

        [Required(ErrorMessage = "Age Required")]
        [Range(18, 120, ErrorMessage = "Max 18 years has book the flight ")]

        public int Age { get; set; }

        [Display(Name = "Phone No")]
        [Required(ErrorMessage = "Phone No Required"), RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Phone No is No vaild")]
        [StringLength(11)]
        public string PhoneNo { get; set; }

        [Display(Name = "NIC No")]
        [Required(ErrorMessage = "NIC Required"), RegularExpression(@"^([0-9]{13})$", ErrorMessage = "Invaild NIC")]
        [StringLength(13)]
        public string NIC { get; set; }

        public int usertype { get; set; } = 2;

    }
}
