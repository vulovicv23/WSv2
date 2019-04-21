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
    public class SerialzeWithIndentTest
    {
        /// <summary>
        /// IJsonProcessor
        /// </summary>
        private readonly IJsonProcessor _jsonProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public SerialzeWithIndentTest()
        {
            var fileProcessor = new WSV2.Common.IO.FileProcessor();
            _jsonProcessor = new WSV2.Common.IO.JsonProcessor(fileProcessor);
        }

        /// <summary>
        /// We provide a InputObject and pass it into the method, we expect that 
        /// it will serialize it to string and that that string will not be emtpy
        /// </summary>
        [Fact]
        public void Test_Construct_File_Filename()
        {
            #region Prepare
            // Path for existing file
            string path = Environment.CurrentDirectory + "\\file.json";
            var inputObject = _jsonProcessor.DeserializeFromPath<InputObject>(path);
            #endregion

            #region Act
            var json = _jsonProcessor.SerialzeWithIndent(inputObject);
            #endregion

            #region Assert
            Assert.NotEmpty(json);
            #endregion
        }
    }
}
