using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CorrectifLabo.Entities
{
    public class Coffret
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Synopsis { get; set; }
        public string PosterUrl { get; set; }
        public int GenreId { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }
        public string Bonus { get; set; }
    }
}
