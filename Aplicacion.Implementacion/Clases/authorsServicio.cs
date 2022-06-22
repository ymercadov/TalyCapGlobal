using Aplicacion.Contratos.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Datos.AgenteServicios;
using Dominio.Contratos;
using Dominio.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Implementacion
{
   public class authorsServicio: IAuthorsServicio
    {

        #region Atributos
        private IAuthorsRepositorio _authorsRepositorio;
        private readonly IMapper _mapper;
        private readonly IFabricaPeticiones fabricaPeticiones;
        #endregion

        #region Constructor
        public authorsServicio(IFabricaPeticiones pFabricaPeticiones,
                        IAuthorsRepositorio pIAuthorsRepositorio, IMapper mapper)
        {
            this._authorsRepositorio = pIAuthorsRepositorio;
            this.fabricaPeticiones = pFabricaPeticiones;
            this._mapper = mapper;
        }
        #endregion

        #region Metodos
        public AuthorsDTO Obtener(int id)
        {
            var objetoRecuperado = _authorsRepositorio.Obtener(id);
            return _mapper.Map<Author, AuthorsDTO>(objetoRecuperado);
        }
        public IEnumerable<AuthorsDTO> ObtenerTodas()
        {
            var lista = _authorsRepositorio.ObtenerTodas();
            return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorsDTO>>(lista);
        }
        public async Task<bool> Agregar(AuthorsDTO entidad)
        {
            try
            {
                var _objeto = new Author();
                _mapper.Map(entidad, _objeto);
                _authorsRepositorio.Agregar(_objeto);
                await _authorsRepositorio.unidadTrabajo.Completar();
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
            List<Author> lstState = new List<Author>();
            Author EnAuthor = new Author();
            string resul=string.Empty;
            int i = 1;
            var Json = this.fabricaPeticiones.RealizarPeticion(url, "GET");
            if (Json.Length > 0)
            {
                var listAuthors = JsonConvert.DeserializeObject<List<AuthorsDTO>>(Json);

                foreach (var author in listAuthors)
                {
                    var respuesta = Agregar(author);
                }
            }
            return resul;
        }


        #endregion

        #region Dispose

        ~authorsServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_authorsRepositorio != null)
                {
                    this._authorsRepositorio.Dispose();
                    this._authorsRepositorio = null;
                }
            }
        }

        #endregion


    }
}
