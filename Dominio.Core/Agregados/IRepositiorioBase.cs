using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dominio.Core
{
    public interface IRepositiorioBase<Entidad> : IDisposable
    {
        IUnidadTrabajo unidadTrabajo { get; }

        //Todos los repositorios que implenten el repositorio Base tendran el mismo comportamiento
        Entidad Obtener(int id); //Select * from Tabla where tablaId = id

        IEnumerable<Entidad> ObtenerTodas(); //Select * from Tabla 

        IEnumerable<Entidad> Buscar(Expression<Func<Entidad, bool>> predicado);

        Entidad BuscarSingleOrDefault(Expression<Func<Entidad, bool>> predicado);
        void Agregar(Entidad entidad);
        void Eliminar(Entidad entidad);
    }
}
