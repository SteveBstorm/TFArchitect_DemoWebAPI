using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.DTOs
{
    public class RegisterClientForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(3)]
        public string Username { get; set; }
    }
}
