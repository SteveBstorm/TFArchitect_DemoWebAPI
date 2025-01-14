using DAL_CorrectifLabo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CorrectifLabo.Interface
{
    public interface ICoffretRepository
    {
        Coffret GetById(int id);
        IEnumerable<Coffret> GetAll();
        void Create(Coffret coffret);
        void ModifyQuantity(int id, int quantity);
    }
}
