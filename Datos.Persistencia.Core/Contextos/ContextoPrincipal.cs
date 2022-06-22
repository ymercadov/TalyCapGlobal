using Dominio.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Persistencia.Core
{
    public class ContextoPrincipal : DbContext, IContextoUnidaDeTrabajo
    {
       
      
 public ContextoPrincipal(DbContextOptions<ContextoPrincipal> options) : base(options) { }


        #region -IContextoUnidaDeTrabajo-

        //Atributos
        DbSet<Books> _books;
        DbSet<Author> _Authos;
        DbSet<Users> _users;
     
        //Propiedades
        public DbSet<Books> books { get { return _books ?? (_books = base.Set<Books>()); } }
        public DbSet<Author> authors { get { return _Authos ?? (_Authos = base.Set<Author>()); } }
        public DbSet<Users> users { get { return _users ?? (_users = base.Set<Users>()); } }
    
        public new DbSet<Entidad> Set<Entidad>() where Entidad : class
        {
            return base.Set<Entidad>();
        }
        public new void Attach<Entidad>(Entidad item) where Entidad : class
        {
            if (Entry(item).State == EntityState.Detached)
            {
                base.Set<Entidad>().Attach(item);
            }
        }

        public void SetModified<Entidad>(Entidad item) where Entidad : class
        {
            Entry(item).State = EntityState.Modified;
        }

        public async Task<int> Completar()
        {
            return base.SaveChanges();
        }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        
    }
}

