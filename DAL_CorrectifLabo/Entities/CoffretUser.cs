using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CorrectifLabo.Entities
{
    public class CoffretUser
    {
        public int CoffretId { get; set; }
        public int UserId { get; set; }
        public DateTime DateAchat { get; set; }
    }
}
