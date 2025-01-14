using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_CorrectifLabo.Models
{
    public class HistoryByCoffret
    {
        public User Acheteur { get; set; }
        public DateTime DateAchat { get; set; }
    }

    public class HistoryByClient
    {
        public Coffret Achat { get; set; }
        public DateTime DateAchat { get; set; }
    }
}
