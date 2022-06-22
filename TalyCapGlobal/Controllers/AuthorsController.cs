using Aplicacion.Contratos.Contratos;
using Datos.AgenteServicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalyCapGlobal.Controllers
{
   
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {        
        private readonly IFabricaPeticiones fabricaPeticiones;
        private readonly IAuthorsServicio authorServicio;
        private readonly Peticiones _peticiones;
        public AuthorsController(IFabricaPeticiones pFabricaPeticiones,
            IOptions<Peticiones> peticiones, IAuthorsServicio pAuthorServicio)
        {
            this._peticiones = peticiones.Value;
            this.fabricaPeticiones = pFabricaPeticiones;
            this.authorServicio = pAuthorServicio;
        }


        [HttpGet]
        public IActionResult Get()
        {
            string url = $"{_peticiones.api.UrlBase}{_peticiones.api.UrlAuthors}";
            try
            {
                var resultado = this.authorServicio.Sincronizar(url);

                /*
                if (resultado == string.Empty)
                {
                    return BadRequest("No se encontraron resultados..!");
                }
                */
                return Ok(resultado);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        //[HttpGet("{id},{id:length(24)}", Name = "GetById")]
        [HttpGet("{id}")]    
        public IActionResult GetById(string id)
        {           
            string url = $"{_peticiones.api.UrlBase}{_peticiones.api.UrlAuthors}{id}";
            try
            {
                var resultado = this.fabricaPeticiones.RealizarPeticion(url, "GET");

                if (resultado == string.Empty)
                {
                    return NotFound("No se encontraron resultados..!");
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
