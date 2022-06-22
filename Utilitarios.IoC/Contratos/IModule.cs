using System;
using System.Collections.Generic;
using System.Text;

namespace Utilitarios.IoC
{
    public interface IModule
    {
        void Initialize(IRegisterModules register);
    }
}
