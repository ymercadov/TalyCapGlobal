using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using Unity;

namespace Utilitarios.IoC
{
    public static class ModuleLoder
    {
        public static void LoadContainer(IUnityContainer container, string path, string pattern)
        {
            var directoryCatalog = new DirectoryCatalog(path, pattern);
            var importDefition = BuildImportDefinition();
            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(directoryCatalog);

                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        IEnumerable<Export> exports = componsitionContainer.GetExports(importDefition);
                        IEnumerable<IModule> modules = exports.Select(export => export.Value as IModule).Where(m => m != null);

                        var register = new RegisterModules(container);

                        foreach (IModule module in modules)
                        {
                            module.Initialize(register);
                        }

                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();

                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException);
                }
                throw;
            }
        }

        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(def => true, typeof(IModule).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }
}
