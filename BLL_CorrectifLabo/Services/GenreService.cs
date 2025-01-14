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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void Create(string label)
        {
            _genreRepository.Create(label);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _genreRepository.GetAll().Select(x => x.ToBLL());
        }

        public Genre GetById(int id)
        {
            return _genreRepository.GetById(id).ToBLL();
        }
    }
}
