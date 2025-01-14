using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_CorrectifLabo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Adresse_Rue { get; set; }
        public int Adresse_Num { get; set; }
        public int Adresse_CP { get; set; }
        public string Adresse_Localite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool IsAdmin { get; set; }

    }
}
