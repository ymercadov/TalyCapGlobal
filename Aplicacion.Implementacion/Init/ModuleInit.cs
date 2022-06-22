using Aplicacion.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using Utilitarios.IoC;

namespace Aplicacion.Implementacion
{
    [Export(typeof(IModule))]
    public class ModuleInit:IModule
    {
        public void Initialize(IRegisterModules register)
        {
            register.RegisterTyper<IBooksServicio, booksServicio>();

        }
    }
}
