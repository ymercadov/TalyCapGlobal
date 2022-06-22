using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contratos
{
    public interface IAuthorsRepositorio: IRepositiorioBase<Author>, IDisposable
    {
    }
}
