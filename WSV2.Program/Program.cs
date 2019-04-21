using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Common;

namespace WSV2.Program
{
    /// <summary>
    /// Main Entrypoint for the Application
    /// </summary>
    class Program
    {
        /// <summary>
        /// Create Container for Autofac
        /// </summary>
        /// <returns>Autofac Container</returns>
        static private IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacCommonModule>();
            builder.RegisterModule<AutofacProgramModule>();
            return builder.Build();
        }

        /// <summary>
        /// This is where program starts, it will call Application.cs Run method
        /// which will then Run the Core of the Application
        /// </summary>
        /// <param name="args">Arguments passed through command line</param>
        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Application>().Run(args);
        }
    }
}
