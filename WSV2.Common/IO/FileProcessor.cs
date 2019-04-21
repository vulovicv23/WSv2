using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WSV2.Common.IO
{
    /// <summary>
    /// This Class will handle all manipulation of File object.
    /// From checking if file exists to constructing file path and checking
    /// if file is a directory.
    /// </summary>
    public class FileProcessor : IFileProcessor
    {
        /// <summary>
        /// Regex used for determining if string starts as a path would start, eg C:\ or D:\
        /// </summary>
        public static readonly string DRIVE_CHECK = "^[a-zA-Z]:\\)*";


        /// <summary>
        /// Checks if file in path exists
        /// </summary>
        /// <param name="path">Path to a file</param>
        /// <returns>true if file exist, false if not</returns>
        public bool DoesFileExist(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Construct file path using command line argument
        /// </summary>
        /// <param name="path">Path supplied from arguments, can be either full path or filename</param>
        /// <returns>Full file path</returns>
        public string ConstructFilePath(string path)
        {
            string fullPath;
            Match result = Regex.Match("file.json", DRIVE_CHECK);

            if (result.Success)
            {
                fullPath = path;
            }
            else
            {
                fullPath = Path.Combine(Environment.CurrentDirectory, path);
            }

            return fullPath;
        }

        /// <summary>
        /// Checks if file in path is of file type
        /// </summary>
        /// <param name="path">Path to a file</param>
        /// <returns>true if file is file, false if not</returns>
        public bool IsFileADirectory(string path)
        {
            // Get the file attributes for file or directory.
            FileAttributes attr = File.GetAttributes(path);

            if (attr.HasFlag(FileAttributes.Directory))
                return true;

            return false;
        }

        /// <summary>
        /// Read contents from a file
        /// </summary>
        /// <param name="path">Path to a file</param>
        /// <returns>Contents from a file</returns>
        public string ReadFromFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }
    }
}
