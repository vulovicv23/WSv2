namespace WSV2.Common.IO
{

    /// <summary>
    /// 
    /// </summary>
    public interface IJsonProcessor
    {

        /// <summary>
        /// Deserialize string from a file to an object
        /// </summary>
        /// <typeparam name="T">Type of Object that we want to Deserialize into</typeparam>
        /// <param name="path">Path to the file where the json file is stored</param>
        /// <returns>Object of T type deserialized from the path given</returns>
        T DeserializeFromPath<T>(string path) where T : class;

        /// <summary>
        /// Serialize object with nice formatting so
        /// we can have a nicely formatted json returned
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>Nicely formatted json string</returns>
        string SerialzeWithIndent(object obj);
    }
}