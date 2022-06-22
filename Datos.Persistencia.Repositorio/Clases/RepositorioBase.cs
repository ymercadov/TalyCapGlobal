using Datos.Persistencia.Core;
using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Datos.Persistencia.Repositorio
{
    public class RepositorioBase<Entidad> : IRepositiorioBase<Entidad> where Entidad : class
    {
        readonly IContextoUnidaDeTrabajo _unidadTrabajo;

        public IUnidadTrabajo unidadTrabajo { get { return _unidadTrabajo; } }

        public RepositorioBase(IContextoUnidaDeTrabajo unidaDeTrabajo)
        {
            this._unidadTrabajo = unidaDeTrabajo;
        }
        public Entidad Obtener(int id)
        {
            return this._unidadTrabajo.Set<Entidad>().Find(id);
        }
        public IEnumerable<Entidad> ObtenerTodas()
        {
            return this._unidadTrabajo.Set<Entidad>().ToList();
        }
        public IEnumerable<Entidad> Buscar(Expression<Func<Entidad, bool>> predicado)
        {
            return this._unidadTrabajo.Set<Entidad>().Where(predicado);
        }

        public Entidad BuscarSingleOrDefault(Expression<Func<Entidad, bool>> predicado)
        {
            return this._unidadTrabajo.Set<Entidad>().Single(predicado);
        }

        public void Agregar(Entidad entidad)
        {
            this._unidadTrabajo.Set<Entidad>().Add(entidad);
        }

        public void Actualizar(Entidad entidad)
        {
            this._unidadTrabajo.Set<Entidad>().Update(entidad);
        }

        public void Eliminar(Entidad entidad)
        {
            this._unidadTrabajo.Set<Entidad>().Remove(entidad);
        }

        public void Dispose()
        {
            this._unidadTrabajo.Dispose();
        }
    }
}
