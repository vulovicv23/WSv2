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
    public class IsFileADirectoryTest
    {
        /// <summary>
        /// IFileProcessor
        /// </summary>
        private readonly IFileProcessor _fileProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public IsFileADirectoryTest()
        {
            _fileProcessor = new WSV2.Common.IO.FileProcessor();
        }

        /// <summary>
        /// We supply a path to a directory and we expect to get True from the function
        /// </summary>
        [Fact]
        public void Test_File_Is_A_Directory()
        {
            #region Prepare
            // Path for existing file
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\IO";
            #endregion

            #region Act
            var fileADirectory = _fileProcessor.IsFileADirectory(path);
            #endregion

            #region Assert
            Assert.True(fileADirectory);
            #endregion
        }

        /// <summary>
        /// We supply a path to a file and we expect to get False from the function
        /// </summary>
        [Fact]
        public void Test_File_Is_A_File()
        {
            #region Prepare
            // Path for existing file
            string path = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())), "file.json");
            #endregion

            #region Act
            var fileADirectory = _fileProcessor.IsFileADirectory(path);
            #endregion

            #region Assert
            Assert.False(fileADirectory);
            #endregion
        }

    }
}
