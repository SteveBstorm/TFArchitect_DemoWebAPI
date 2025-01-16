using BLL_CorrectifLabo.Interface;
using BLL_CorrectifLabo.Services;
using DemoWebAPI.DTOs;
using DemoWebAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController(IGenreService _genreService) : ControllerBase
    {
        /// <summary>
        /// Que fait mon action ?
        /// </summary>
        /// <param name="form">Attends un label de type string</param>
        /// <returns>Ne retourne rien</returns>
        /// <remarks>Faut pas respirer la compote ça fait tousser</remarks>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(GenreForm form)
        {
            try
            {
                _genreService.Create(form.Label);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retourne la liste des genres disponibles
        /// </summary>
        /// <remarks>Tableau d'objet de type Genre</remarks>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult GetAll()
        {
            return Ok(_genreService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_genreService.GetById(id));
            }
            catch(ArgumentNullException ex)
            {
                return NotFound("Le genre demandé n'existe pas");
            }
        }
    }
}
