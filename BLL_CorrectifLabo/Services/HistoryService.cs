using BLL_CorrectifLabo.Interface;
using BLL_CorrectifLabo.Models;
using DAL_CorrectifLabo.Entities;
using DAL_CorrectifLabo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_CorrectifLabo.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly ICoffretService _coffretService;
        private readonly IUserService _userService;
        private readonly ICoffretUserRepository _coffretUserRepository;

        public HistoryService(ICoffretService coffretService, IUserService userService, ICoffretUserRepository coffretUserRepository)
        {
            _coffretService = coffretService;
            _userService = userService;
            _coffretUserRepository = coffretUserRepository;
        }

        public IEnumerable<HistoryByCoffret> GetHistoryByCoffret(int coffretId)
        {
            IEnumerable<CoffretUser> History = _coffretUserRepository.GetHistoryByCoffretId(coffretId);
            
            List<HistoryByCoffret> historyByCoffrets = new List<HistoryByCoffret>();
            foreach(CoffretUser c in History)
            {
                historyByCoffrets.Add(new HistoryByCoffret
                {
                    Acheteur = _userService.GetById(c.UserId),
                    DateAchat = c.DateAchat
                });
            }

            return historyByCoffrets;

        }

        public IEnumerable<HistoryByClient> GetHistoryByUser(int userId)
        {
            IEnumerable<CoffretUser> History = _coffretUserRepository.GetHistoryByClientId(userId);

            List<HistoryByClient> historyByCoffrets = new List<HistoryByClient>();
            foreach (CoffretUser c in History)
            {
                historyByCoffrets.Add(new HistoryByClient
                {
                    Achat = _coffretService.GetById(c.CoffretId),
                    DateAchat = c.DateAchat
                });
            }

            return historyByCoffrets;
        }
    }
}
