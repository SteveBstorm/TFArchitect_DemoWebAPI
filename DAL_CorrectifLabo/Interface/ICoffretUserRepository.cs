using DAL_CorrectifLabo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CorrectifLabo.Interface
{
    public interface ICoffretUserRepository
    {
        IEnumerable<CoffretUser> GetHistoryByClientId(int clientId);
        IEnumerable<CoffretUser> GetHistoryByCoffretId(int coffretId);

        void CreateCommande(int coffretId, int userId);
    }
}
