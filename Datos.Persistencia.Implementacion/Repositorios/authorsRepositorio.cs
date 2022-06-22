using Datos.Persistencia.Core;
using Datos.Persistencia.Repositorio;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Persistencia.Implementacion
{
    public class AuthorsRepositorio : RepositorioBase<Author>, IAuthorsRepositorio
    {
        public AuthorsRepositorio(IContextoUnidaDeTrabajo unidaDeTrabajo) : base(unidaDeTrabajo) { }

    }
}
