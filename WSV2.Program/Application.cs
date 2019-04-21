using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Common.Exception;
using WSV2.Common.IO;
using WSV2.Program.Processor;

namespace WSV2.Program
{
    /// <summary>
    /// Main Entrypoint for the Program. In order to use
    /// Autofac, we need to include Main Entrypoint as a separate
    /// Class than Program.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// IArgumentProcessor for using methods regarding Validation of the input arguments
        /// </summary>
        private readonly IArgumentProcessor _argumentExceptionProcessor;

        /// <summary>
        /// ICloneProcessor for using methods regarding core Application funcionality, cloning, creating new Entities, Links
        /// </summary>
        private readonly ICloneProcessor _cloneProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="argumentExceptionProcessor">Instance of IArgumentProcessor</param>
        /// <param name="cloneProcessor">Instance of ICloneProcessor</param>
        public Application(IArgumentProcessor argumentExceptionProcessor, ICloneProcessor cloneProcessor)
        {
            _argumentExceptionProcessor = argumentExceptionProcessor;
            _cloneProcessor = cloneProcessor;
        }

        /// <summary>
        /// Run method will be called from Program.cs and will behave
        /// as Entrypoint for Autofac and for our Application. All logic
        /// will happen here.
        /// </summary>
        /// <param name="args">Arguments passed through command line</param>
        public void Run(string[] args)
        {
            // Check if there are any errors with input
            var errors = _argumentExceptionProcessor.HandleArguments(ref args);

            if (errors != null)
            {
                // Go through all errors and print them for user to see
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
                Console.WriteLine("Press any key to exit");

                Console.ReadKey();
            }
            else
            {
                string output = null;
                try
                {
                    output = _cloneProcessor.DoCloning(args);
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Malformed json");
                    Console.WriteLine("Press any key to exit");

                    Console.ReadKey();
                }
                catch (JsonSerializationException jsonException)
                {
                    Console.WriteLine(jsonException.Message);
                    Console.WriteLine("Press any key to exit");

                    Console.ReadKey();
                }
                catch (RootObjectNotFound rootObjectNotFound)
                {
                    Console.WriteLine(rootObjectNotFound.Message);
                    Console.WriteLine("Press any key to exit");

                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to exit");

                    Console.ReadKey();
                }

                if (output != null)
                {
                    Console.WriteLine("Results are:");
                    Console.WriteLine(output);
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                }
            }
        }
    }
}
