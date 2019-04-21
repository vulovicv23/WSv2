namespace WSV2.Program.Processor
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICloneProcessor
    {
        /// <summary>
        /// Handle the main logic for cloning json file and creating the core funcionality
        /// </summary>
        /// <param name="args">Arguments passed through command line</param>
        /// <returns>Json string when the whole process is done</returns>
        string DoCloning(string[] args);
    }
}