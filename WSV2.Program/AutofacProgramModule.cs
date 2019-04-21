using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Common.IO;

namespace WSV2.Program
{
    /// <summary>
    /// Class for registering all modules in WSV2.Program Project
    /// </summary>
    class AutofacProgramModule : Module
    {
        /// <summary>
        /// Registering all necessary components in WSV2.Program Project
        /// </summary>
        /// <param name="builder">Autofac builder object</param>
        protected override void Load(ContainerBuilder builder)
        {
            //Get the program assembly so we can register components by filtering them
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
               .Where(t => t.Name.EndsWith("Processor"))
               .AsImplementedInterfaces();

            builder.RegisterType<Application>();
        }
    }
}
