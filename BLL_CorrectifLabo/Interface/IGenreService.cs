using BLL_CorrectifLabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_CorrectifLabo.Interface
{
    public interface IGenreService
    {
        void Create(string label);
        IEnumerable<Genre> GetAll();
        Genre GetById(int id);
    }
}
