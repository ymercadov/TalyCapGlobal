using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core
{
    public interface IUnidadTrabajo : IDisposable
    {
        Task<int> Completar(); //Completar
    }
}
