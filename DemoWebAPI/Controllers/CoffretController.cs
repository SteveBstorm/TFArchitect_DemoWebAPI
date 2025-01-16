using BLL_CorrectifLabo.Interface;
using DemoWebAPI.DTOs;
using DemoWebAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffretController(ICoffretService _coffretService, IHistoryService _historyService) : ControllerBase
    {
        [HttpPost("create")]
        public IActionResult Create(CoffretForm form)
        {
            try
            {
                _coffretService.Create(form.ToBLL());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("liste")]
        public IActionResult GetAll()
        {
            return Ok(_coffretService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_coffretService.GetById(id));
        }


        [HttpPatch("modifQuantity")]
        public IActionResult ModifyQty(ModifyQtyForm form)
        {
            try
            {
                _coffretService.ModifyQuantity(form.CoffretId, form.NewQuantity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

                
            }
        }

        [HttpPost("command")]
        public IActionResult CreateCommand(CommandForm form)
        {
            try
            {
                _coffretService.Command(form.CoffretId, form.ClientId);
                return Ok();
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("history/{coffretid}")]
        public IActionResult GetHistory(int coffretid)
        {
            try
            {
                return Ok(_historyService.GetHistoryByCoffret(coffretid));
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }

    }
}
