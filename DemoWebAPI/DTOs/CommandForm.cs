using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.DTOs
{
    public class CommandForm
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int CoffretId { get; set; }
    }
}
