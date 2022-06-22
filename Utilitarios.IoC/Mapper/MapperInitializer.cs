using Aplicacion.Core;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilitarios.IoC
{
    public class MapperInitializer
    {
        public static void ConfigurarMapeos()
        {
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile<MapperProfile>();
            });
        }
    }
}
