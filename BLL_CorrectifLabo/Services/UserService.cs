using BLL_CorrectifLabo.Interface;
using BLL_CorrectifLabo.Models;
using BLL_CorrectifLabo.Tools;
using DAL_CorrectifLabo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_CorrectifLabo.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll().Select(x => x.ToBLL());
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id).ToBLL();
        }

        public User Login(string email, string password)
        {
            User currentUser;
            string hashPwd;
            try
            {
                hashPwd = _userRepository.GetPassword(email);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            if (BCrypt.Net.BCrypt.Verify(password, hashPwd))
            {
                currentUser = _userRepository.GetByEmail(email).ToBLL();
                return currentUser;
            }
            throw new ArgumentException("Mot de passe incorrect");
        }

        public void Register(User user, string password)
        {
            string hashPwd = BCrypt.Net.BCrypt.HashPassword(password);
            _userRepository.Register(user.ToDAL(), hashPwd);
        }

        public void UpdateDeliveryInfo(int id, string ad_rue, string ad_num, string ad_cp, string ad_loc)
        {
            _userRepository.UpdateDeliveryInfo(id, ad_rue, ad_num, ad_cp, ad_loc);
        }

        public void UpdatePassword(int id, string password)
        {
            _userRepository.UpdatePassword(id, password);
        }
    }
}
