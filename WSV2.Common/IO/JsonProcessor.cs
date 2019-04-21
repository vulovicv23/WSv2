using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSV2.Common.IO
{
    /// <summary>
    /// This Class will do Json manipulation and it uses Newtonsoft library and encapsulates it,
    /// creates a wrapper that suits the needs for this application
    /// </summary>
    public class JsonProcessor : IJsonProcessor
    {

        /// <summary>
        /// IFileProcessor for using methods concerning File manipulation 
        /// </summary>
        private readonly IFileProcessor _fileProcessor;

        /// <summary>
        /// Json Serializer Settings used to add settings on how json is Serialized
        /// </summary>
        private readonly JsonSerializerSettings _jsonWriter;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileProcessor">Instance of IFileProcessor</param>
        public JsonProcessor(IFileProcessor fileProcessor)
        {
            _fileProcessor = fileProcessor;
            _jsonWriter = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }


        /// <summary>
        /// Deserialize string from a file to an object
        /// </summary>
        /// <typeparam name="T">Type of Object that we want to Deserialize into</typeparam>
        /// <param name="path">Path to the file where the json file is stored</param>
        /// <returns>Object of T type deserialized from the path given</returns>
        public T DeserializeFromPath<T>(string path) where T : class
        {
            // String representation of file content
            string content = _fileProcessor.ReadFromFile(path);

            // Deserialize content to our object
            var obj = JsonConvert.DeserializeObject<T>(content);

            return obj;
        }



        /// <summary>
        /// Serialize object with nice formatting so
        /// we can have a nicely formatted json returned
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>Nicely formatted json string</returns>
        public string SerialzeWithIndent(object obj)
        {
            string result = JsonConvert.SerializeObject(obj, Formatting.Indented, _jsonWriter);

            return result;
        }
    }
}
