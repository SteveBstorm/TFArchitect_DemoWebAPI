using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DemoWebAPI.DTOs
{
    public class UserRegisterForm
    {
        [Required]
        [EmailAddress]
        [DisplayName("Adresse email")]
        public string Email { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string Adresse_Rue { get; set; }
        public int Adresse_Num { get; set; }
        public int Adresse_CP { get; set; }
        public string Adresse_Localite { get; set; }
    }
}
