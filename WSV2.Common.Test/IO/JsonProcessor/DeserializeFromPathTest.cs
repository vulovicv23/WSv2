using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Common.IO;
using WSV2.Program.Model;
using Xunit;

namespace WSV2.Common.Test.IO.JsonProcessor
{
    public class DeserializeFromPathTest
    {
        /// <summary>
        /// IJsonProcessor
        /// </summary>
        private readonly IJsonProcessor _jsonProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public DeserializeFromPathTest()
        {
            var fileProcessor = new WSV2.Common.IO.FileProcessor();
            _jsonProcessor = new WSV2.Common.IO.JsonProcessor(fileProcessor);
        }

        /// <summary>
        /// We provide path to a file that contains json with json elements inside
        /// and we want it to deserialize it to our object and assert that that object is 
        /// not null
        /// </summary>
        [Fact]
        public void Test_Construct_File_Filename()
        {
            #region Prepare
            // Path for existing file
            string path = Environment.CurrentDirectory + "\\file.json";
            #endregion

            #region Act
            var inputObject = _jsonProcessor.DeserializeFromPath<InputObject>(path);
            #endregion

            #region Assert
            Assert.NotNull(inputObject);
            #endregion
        }
    }
}
