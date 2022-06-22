using Aplicacion.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Contratos
{
    public interface IBooksServicio: IDisposable
    {
        BooksDTO Obtener(int id);
        IEnumerable<BooksDTO> ObtenerTodas(); ////Select * from Casa   
        Task<bool> Agregar(BooksDTO entidad);
        string Sincronizar(string url);
    }
}
