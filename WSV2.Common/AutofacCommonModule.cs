using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSV2.Common
{
    /// <summary>
    /// Class for registering all modules in WSV2.Common Project
    /// </summary>
    public class AutofacCommonModule : Module
    {
        /// <summary>
        /// Registering all necessary components in WSV2.Common Project
        /// </summary>
        /// <param name="builder">Autofac builder object</param>
        protected override void Load(ContainerBuilder builder)
        {
            //Get the program assembly so we can register components by filtering them
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
               .Where(t => t.Name.EndsWith("Processor"))
               .AsImplementedInterfaces();
        }
    }
}
