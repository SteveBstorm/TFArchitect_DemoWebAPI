using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.DTOs
{
    public class ModifyQtyForm
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int CoffretId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int NewQuantity { get; set; }
    }
}
