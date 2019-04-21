namespace WSV2.Common.IO
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFileProcessor
    {
        /// <summary>
        /// Checks if file in path exists
        /// </summary>
        /// <param name="path">Path to a file</param>
        /// <returns>true if file exist, false if not</returns>
        bool DoesFileExist(string path);

        /// <summary>
        /// Construct file path using command line argument
        /// </summary>
        /// <param name="path">Path supplied from arguments, can be either full path or filename</param>
        /// <returns>Full file path</returns>
        string ConstructFilePath(string path);

        /// <summary>
        /// Checks if file in path is of file type
        /// </summary>
        /// <param name="path">Path to a file</param>
        /// <returns>true if file is file, false if not</returns>
        bool IsFileADirectory(string path);

        /// <summary>
        /// Read contents from a file
        /// </summary>
        /// <param name="path">Path to a file</param>
        /// <returns>Contents from a file</returns>
        string ReadFromFile(string path);
    }
}