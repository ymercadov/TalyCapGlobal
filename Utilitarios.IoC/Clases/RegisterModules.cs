using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Lifetime;

namespace Utilitarios.IoC
{
    public class RegisterModules : IRegisterModules
    {
        private readonly IUnityContainer _contenedor;

        public RegisterModules(IUnityContainer contenedor)
        {
            _contenedor = contenedor;
        }

        public void RegisterTyper<ToFrom, TTo>(bool withIterception = false) where TTo : ToFrom
        {
            if (!withIterception)
            {
                _contenedor.RegisterType<ToFrom, TTo>();
            }
        }

        public void RegisterTypeWithLifeTime<ToFrom, TTo>(bool withIterception = false) where TTo : ToFrom
        {
            _contenedor.RegisterType<ToFrom, TTo>(new ContainerControlledLifetimeManager());
        }
    }
}
