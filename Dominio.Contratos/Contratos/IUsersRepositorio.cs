using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contratos.Contratos
{
    public interface IUsersRepositorio: IRepositiorioBase<Author>, IDisposable
    {
    }
}
