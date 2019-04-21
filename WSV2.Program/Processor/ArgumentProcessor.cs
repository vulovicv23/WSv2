using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Common.IO;

namespace WSV2.Program.Processor
{
    /// <summary>
    /// This Class will handle all the logic for validating
    /// and making sure that arguments passed are valid.
    /// That means checking if the ID is really a number
    /// and if path provided can be combined and if that
    /// combined path actually exist and if the File that 
    /// is found on path really a file
    /// </summary>
    public class ArgumentProcessor : IArgumentProcessor
    {
        /// <summary>
        /// IFileProcessor for using methods concerning File manipulation 
        /// </summary>
        private readonly IFileProcessor _fileProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileProcessor">Instance of IFileProcessor</param>
        public ArgumentProcessor(IFileProcessor fileProcessor)
        {
            _fileProcessor = fileProcessor;
        }

        /// <summary>
        /// This method will chec if all arguments are present
        /// and if all arguments satisfy object type and if
        /// are all object valid
        /// </summary>
        /// <param name="args">Arguments passed through command line</param>
        /// <returns>List of strings if there are any errors, NULL if there are none</returns>
        public List<string> HandleArguments(ref string[] args)
        {
            List<string> errorList = new List<string>();

            //Check if argument array is not null.
            if (args == null)
            {
                errorList.Add("Arguments array cannot be null");
                return errorList;
            }

            //Check for the length of the argument array. Argument array length must be 2.
            if (args.Length != 2)
            {
                errorList.Add("Number of arguments must be equal to 2");
                return errorList;
            }

            // Validate File
            string fileError = CheckFile(ref args);

            if (fileError != null)
            {
                errorList.Add(fileError);
            }

            // Validate Entity Id
            string entityIdError = CheckEntityId(args[1]);

            if (entityIdError != null)
                errorList.Add(entityIdError);

            // If any error, return list with errors
            if (fileError != null || entityIdError != null)
                return errorList;

            return null;
        }

        /// <summary>
        /// Check and validate entity id
        /// </summary>
        /// <param name="argsEntityId">EntityId from the argument array</param>
        /// <returns>String if there was any error during validation, NULL if there are none</returns>
        public string CheckEntityId(string argsEntityId)
        {
            // Entity Id provided from argument array, assuming that user passed in 2 arguments, 1st long, second string.
            long entityId;
            bool isEntityIdLong = long.TryParse(argsEntityId, out entityId);

            // Check if entityId is a number
            if (!isEntityIdLong)
                return "Entity Id must be a number";

            return null;
        }

        /// <summary>
        /// Check, validate path and assign new path to the arguments 
        /// </summary>
        /// <param name="args">Arguments passed through command line</param>
        /// <returns>String if there was any error during validation, NULL if there are none</returns>
        public string CheckFile(ref string[] args)
        {
            var filePath = _fileProcessor.ConstructFilePath(args[0]);

            // Check if file path is not null
            if (filePath == null)
            {
                return "File does not exist";
            }

            // Check if file path exists
            if (!_fileProcessor.DoesFileExist(filePath))
            {
                return "File does not exist";
            }

            // Check if file is a directory
            if (_fileProcessor.IsFileADirectory(filePath))
            {
                return "File is a directory";
            }

            args[0] = filePath;

            return null;
        }
    }
}
