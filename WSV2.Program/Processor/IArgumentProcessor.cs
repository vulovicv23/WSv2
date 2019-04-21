using System.Collections.Generic;

namespace WSV2.Program.Processor
{
    /// <summary>
    /// 
    /// </summary>
    public interface IArgumentProcessor
    {
        /// <summary>
        /// This method will chec if all arguments are present
        /// and if all arguments satisfy object type and if
        /// are all object valid
        /// </summary>
        /// <param name="args">Arguments passed through command line</param>
        /// <returns>List of strings if there are any errors, NULL if there are none</returns>
        List<string> HandleArguments(ref string[] args);
    }
}