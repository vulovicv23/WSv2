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
    public class ConstructFilePathTest
    {
        /// <summary>
        /// IFileProcessor
        /// </summary>
        private readonly IFileProcessor _fileProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public ConstructFilePathTest()
        {
            _fileProcessor = new WSV2.Common.IO.FileProcessor();
        }

        /// <summary>
        /// In this case, we provide full path, eg: C:\Program Files\file.json
        /// and we expect that the file path will stay the same, since it is 
        /// absolute file path.
        /// </summary>
        [Fact]
        public void Test_Construct_File_Full_Path()
        {
            #region Prepare
            // Path for existing file
            string path = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())), "file.json");
            #endregion

            #region Act
            var fullPath = _fileProcessor.ConstructFilePath(path);
            #endregion

            #region Assert
            Assert.Equal(path, fullPath);
            #endregion
        }

        /// <summary>
        /// In This case we provide partial path eg. test\file.json and function
        /// needs to combine the path from where the program was called with this path that
        /// we supplied.
        /// </summary>
        [Fact]
        public void Test_Construct_File_Partial_Path()
        {
            #region Prepare
            // Path for existing file
            string path = "test\\file.json";
            string expected = Environment.CurrentDirectory + "\\test\\file.json";
            #endregion

            #region Act
            var fullPath = _fileProcessor.ConstructFilePath(path);
            #endregion

            #region Assert
            Assert.Equal(expected, fullPath);
            #endregion
        }

        /// <summary>
        /// In this case we provide only filename, and our method needs to understand this
        /// and to take into account from where was the application called
        /// and function needs to return us combined directory from where the application was called
        /// plus the filename.
        /// </summary>
        [Fact]
        public void Test_Construct_File_Filename()
        {
            #region Prepare
            // Path for existing file
            string path = "file.json";
            string expected = Environment.CurrentDirectory + "\\file.json";
            #endregion

            #region Act
            var fullPath = _fileProcessor.ConstructFilePath(path);
            #endregion

            #region Assert
            Assert.Equal(expected, fullPath);
            #endregion
        }
    }
}
