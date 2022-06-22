using Aplicacion.Contratos;
using Datos.AgenteServicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalyCapGlobal.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IFabricaPeticiones fabricaPeticiones;
        private readonly IBooksServicio booksServicio;
        private readonly Peticiones _peticiones;
        public BooksController(IFabricaPeticiones pFabricaPeticiones,
            IOptions<Peticiones> peticiones, IBooksServicio pBooksServicio)
        {
            this._peticiones = peticiones.Value;
            this.fabricaPeticiones = pFabricaPeticiones;
            this.booksServicio = pBooksServicio;
        }
       
        [HttpGet]
        public IActionResult Get()
        {
            string url = $"{_peticiones.api.UrlBase}{_peticiones.api.UrlBooks}";
            try
            {
                var resultado = this.booksServicio.Sincronizar(url);
/*
                if (resultado == string.Empty)
                {
                    return BadRequest("No se encontraron resultados..!");
                }*/
                return Ok(resultado);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
           
            string url = $"{_peticiones.api.UrlBase}{_peticiones.api.UrlBooks}{id}";
            try
            {
                var resultado = this.fabricaPeticiones.RealizarPeticion(url, "GET");

                if (resultado == string.Empty)
                {
                    return BadRequest("No se encontraron resultados..!");
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
