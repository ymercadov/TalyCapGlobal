using Aplicacion.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Contratos.Contratos
{
    public interface IAuthorsServicio:IDisposable
    {
        AuthorsDTO Obtener(int id);
        IEnumerable<AuthorsDTO> ObtenerTodas(); ////Select * from Casa   
        Task<bool> Agregar(AuthorsDTO entidad);
        string Sincronizar(string url);
    }
}
