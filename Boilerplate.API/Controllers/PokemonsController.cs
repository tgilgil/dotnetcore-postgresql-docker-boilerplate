using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Pokemons")]
    public class PokemonsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Id = 1, Name = "Bulbausaur" });
        }
    }
}