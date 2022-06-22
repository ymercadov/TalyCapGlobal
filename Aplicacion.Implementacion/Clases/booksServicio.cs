using Aplicacion.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Datos.AgenteServicios;
using Dominio.Contratos;
using Dominio.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Implementacion
{
    public class booksServicio: IBooksServicio
    {
        #region Atributos
        private IBooksRepositorio _booksRepositorio;
        private readonly IMapper _mapper;
        private readonly IFabricaPeticiones fabricaPeticiones;
        #endregion

        #region Constructor
        public booksServicio(IFabricaPeticiones pFabricaPeticiones,
                        IBooksRepositorio pIBooksRepositorio, IMapper mapper)
        {
            this._booksRepositorio = pIBooksRepositorio;
            this.fabricaPeticiones = pFabricaPeticiones;
            this._mapper = mapper;
        }
        #endregion

        #region Metodos
        public BooksDTO Obtener(int id)
        {
            var objetoRecuperado = _booksRepositorio.Obtener(id);
            return _mapper.Map<Books, BooksDTO>(objetoRecuperado);
        }
        public IEnumerable<BooksDTO> ObtenerTodas()
        {
            var lista = _booksRepositorio.ObtenerTodas();
            return _mapper.Map<IEnumerable<Books>, IEnumerable<BooksDTO>>(lista);
        }
        public async Task<bool> Agregar(BooksDTO entidad)
        {
            try
            {
                var _objeto = new Books();
                _mapper.Map(entidad, _objeto);
                _booksRepositorio.Agregar(_objeto);
                await _booksRepositorio.unidadTrabajo.Completar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
                return false;
            }
        }

        public string Sincronizar(string url)
        {
            /*var lista = _booksRepositorio.ObtenerTodas();
            if (lista)*/
            List<Books> lstState = new List<Books>();
            Books EnBooks = new Books();
            string resul = string.Empty;
            int i = 1;
            var Json = this.fabricaPeticiones.RealizarPeticion(url, "GET");
            if (Json.Length > 0)
            {
                var listBooks = JsonConvert.DeserializeObject<List<BooksDTO>>(Json);

                foreach (var book in listBooks)
                {
                    var resultado =  Agregar(book);
                }

            }
            return resul;
        }


        #endregion

        #region Dispose

        ~booksServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_booksRepositorio != null)
                {
                    this._booksRepositorio.Dispose();
                    this._booksRepositorio = null;
                }
            }
        }

        #endregion
    }


}
