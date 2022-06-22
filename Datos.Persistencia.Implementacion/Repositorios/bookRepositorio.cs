using Datos.Persistencia.Core;
using Datos.Persistencia.Repositorio;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Persistencia.Implementacion
{
    public class BookRepositorio : RepositorioBase<Books>, IBooksRepositorio
    {
        public BookRepositorio(IContextoUnidaDeTrabajo unidaDeTrabajo) : base(unidaDeTrabajo) { }
    
    }
}
