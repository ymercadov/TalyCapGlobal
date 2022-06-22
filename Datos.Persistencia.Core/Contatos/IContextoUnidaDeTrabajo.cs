using Dominio.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;

namespace Datos.Persistencia.Core
{
    public interface IContextoUnidaDeTrabajo: IUnidadTrabajo, IDisposable
    {
        DbSet<Books> books { get; }
     
        DbSet<Author> authors { get; }
        DbSet<Users> users { get; }

        DbSet<Entidad> Set<Entidad>() where Entidad : class;

        void Attach<Entidad>(Entidad item) where Entidad : class;

        void SetModified<Entidad>(Entidad item) where Entidad : class;
    }
}
