using BLL_CorrectifLabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_CorrectifLabo.Interface
{
    public interface ICoffretService
    {
        Coffret GetById(int id);
        IEnumerable<Coffret> GetAll();
        void Create(Coffret coffret);
        void ModifyQuantity(int coffretId, int quantity);
        void Command(int coffretId, int userId);
    }
}
