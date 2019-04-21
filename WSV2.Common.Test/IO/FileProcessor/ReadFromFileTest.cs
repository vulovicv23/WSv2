using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Common.IO;
using Xunit;

namespace WSV2.Common.Test.IO.FileProcessor
{
    public class ReadFromFileTest
    {
        /// <summary>
        /// IFileProcessor
        /// </summary>
        private readonly IFileProcessor _fileProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public ReadFromFileTest()
        {
            _fileProcessor = new WSV2.Common.IO.FileProcessor();
        }

        /// <summary>
        /// We supply a path to an existing file and the function should return a string
        /// that is contained in the file
        /// </summary>
        [Fact]
        public void Test_Read_File_Content()
        {
            #region Prepare
            // Path for existing file
            string path = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())), "file.json");
            #endregion

            #region Act
            var content = _fileProcessor.ReadFromFile(path);
            #endregion

            #region Assert
            Assert.NotEmpty(content);
            #endregion
        }
    }
}
