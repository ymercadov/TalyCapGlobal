using Datos.Persistencia.Core;
using Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using Utilitarios.IoC;

namespace Datos.Persistencia.Implementacion
{
    [Export(typeof(IModule))]
    public class ModuleIInit : IModule
    {

        public void Initialize(IRegisterModules register)
        {
            register.RegisterTyper<IContextoUnidaDeTrabajo, ContextoPrincipal>();
            register.RegisterTyper<IBooksRepositorio, BookRepositorio>();

        }
    }
}
