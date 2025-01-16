using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.DTOs
{
    public class CoffretForm
    {
        [Required]
        public string Titre { get; set; }
        [Required]
        [MinLength(20)]
        public string Synopsis { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string PosterUrl { get; set; }
        [Required]
        public int GenreId { get; set; }
        public decimal Prix { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantite { get; set; }
        public string Bonus { get; set; }
    }
}
