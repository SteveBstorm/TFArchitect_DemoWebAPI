using BLL_CorrectifLabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_CorrectifLabo.Interface
{
    public interface IUserService
    {
        void Register(User user, string password);
        User GetById(int id);
        User Login(string email, string password);
        IEnumerable<User> GetAll();
        void UpdatePassword(int id, string password);
        void UpdateDeliveryInfo(int id, string ad_rue, string ad_num, string ad_cp, string ad_loc);
    }
}
