using DAL_CorrectifLabo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CorrectifLabo.Interface
{
    public interface IUserRepository
    {
        void Register(User user, string password);
        User GetByEmail(string email);
        User GetById(int id);
        string GetPassword(string email);
        IEnumerable<User> GetAll();
        void UpdatePassword(int id, string password);
        void UpdateDeliveryInfo(int id, string ad_rue, string ad_num, string ad_cp, string ad_loc);

    }
}
