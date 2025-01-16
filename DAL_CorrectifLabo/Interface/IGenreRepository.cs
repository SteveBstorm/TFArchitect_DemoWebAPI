using DAL_CorrectifLabo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CorrectifLabo.Interface
{
    public interface IGenreRepository
    {
        void Create(string label);
        Genre? GetById(int id);
        IEnumerable<Genre> GetAll();
    }
}
