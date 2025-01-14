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
    public class CoffretService : ICoffretService
    {
        private readonly ICoffretRepository _coffretRepository;
        private readonly ICoffretUserRepository _coffretUserRepository;
   
        public CoffretService(ICoffretRepository coffretRepository, ICoffretUserRepository coffretUserRepository)
        {
            _coffretRepository = coffretRepository;
            _coffretUserRepository = coffretUserRepository;
        }

        public void Create(Coffret coffret)
        {
            _coffretRepository.Create(coffret.ToDAL());
        }

        public IEnumerable<Coffret> GetAll()
        {
            return _coffretRepository.GetAll().Select(x => x.ToBLL());
        }

        public Coffret GetById(int id)
        {
            return _coffretRepository.GetById(id).ToBLL();
        }

        public void Command(int coffretId, int userId, int newqty)
        {
            _coffretUserRepository.CreateCommande(coffretId, userId);
            _coffretRepository.ModifyQuantity(coffretId, newqty);
        }

        public void ModifyQuantity(int coffretId, int  quantity)
        {
            _coffretRepository.ModifyQuantity(coffretId, quantity);
        }
    }
}
