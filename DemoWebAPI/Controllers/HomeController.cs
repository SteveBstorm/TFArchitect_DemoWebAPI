using DemoWebAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Toto()
        {
            return Ok("Salut");
        }

        [HttpGet("getinfo")]
        public IActionResult Toto2()
        {
            return Ok("Coucou");
        }
        [HttpGet("{toto}")]
        public IActionResult Toto3([FromRoute]int toto) 
        {
            if (toto == 42) return NotFound();
            return Ok(toto);
        }

        [HttpPost("register")]
        public IActionResult RegisterClient([FromBody]RegisterClientForm form)
        {
            return Ok(form);
        }

        [HttpPost("login/email/{email}/password/{password}")]
        public IActionResult LoginClient(string email, string password)
        {
            return Ok();
        }
    }
}
 

/*
 Regle du Rest API

    1) 1 controller = 1 ressource
        => Gérer toute les actions pour cette ressource
    2) Le bon verbe pour la bonne action
    3) Chaque ressource est identifiée de manière unique (id)
    4) Route doivent être "developer-friendly"
 */