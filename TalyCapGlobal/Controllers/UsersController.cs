using Datos.AgenteServicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalyCapGlobal.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IFabricaPeticiones fabricaPeticiones;
        private readonly Peticiones _peticiones;
        public UsersController(IFabricaPeticiones pFabricaPeticiones,
            IOptions<Peticiones> peticiones)
        {
            this._peticiones = peticiones.Value;
            this.fabricaPeticiones = pFabricaPeticiones;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string url = $"{_peticiones.api.UrlBase}{_peticiones.api.UrlUsers}";
            try
            {
                var resultado = this.fabricaPeticiones.RealizarPeticion(url, "GET");

                if (resultado == string.Empty)
                {
                    return BadRequest("No se encontraron resultados..!");
                }
                else { 
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }
    }
}
