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
    public class DoesFileExistTest
    {
        /// <summary>
        /// IFileProcessor
        /// </summary>
        private readonly IFileProcessor _fileProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public DoesFileExistTest()
        {
            _fileProcessor = new WSV2.Common.IO.FileProcessor();
        }

        /// <summary>
        /// We provide a path to a file that exist and we expect that return value
        /// will be True
        /// </summary>
        [Fact]
        public void Test_File_Exist()
        {
            #region Prepare
            // Path for existing file
            string path = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())), "file.json");
            #endregion

            #region Act
            var fileExist = _fileProcessor.DoesFileExist(path);
            #endregion

            #region Assert
            Assert.True(fileExist);
            #endregion
        }

        /// <summary>
        /// We provide a path to a file that doesn't exist and we expect that return value
        /// will be False
        /// </summary>
        [Fact]
        public void Test_File_Doesnt_Exist()
        {
            #region Prepare
            // Path for existing file
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\file_something.json";
            #endregion

            #region Act
            var fileExist = _fileProcessor.DoesFileExist(path);
            #endregion

            #region Assert
            Assert.False(fileExist);
            #endregion
        }
    }
}
