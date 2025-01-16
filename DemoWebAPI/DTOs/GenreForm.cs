using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.DTOs
{
    public class GenreForm
    {
        [Required]
        public string Label { get; set; }
    }
}
