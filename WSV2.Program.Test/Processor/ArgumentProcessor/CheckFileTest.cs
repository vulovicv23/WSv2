using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Common.IO;
using WSV2.Program.Processor;
using Xunit;

namespace WSV2.Program.Test.Processor.ArgumentProcessor
{
    public class CheckFileTest
    {
        /// <summary>
        /// ArgumentProcessor
        /// </summary>
        private readonly WSV2.Program.Processor.ArgumentProcessor _argumentProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public CheckFileTest()
        {
            var fileProcessor = new FileProcessor();
            _argumentProcessor = new WSV2.Program.Processor.ArgumentProcessor(fileProcessor);
        }

        /// <summary>
        /// We are checking if there will be any errors if the supplied string
        /// is actually a valid path, we expect to return null
        /// </summary>
        [Fact]
        public void Check_File_Good()
        {
            #region Prepare
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\file.json";
            string[] args = new string[] { path, "1" };
            #endregion

            #region Act
            var error = _argumentProcessor.CheckFile(ref args);
            #endregion

            #region Assert
            Assert.Null(error);
            #endregion
        }

        /// <summary>
        /// We are checking if there will be any errors if the supplied string
        /// is actually a valid path, we supplied a wrong path, we expect to return error
        /// </summary>
        [Fact]
        public void Check_File_Doesnt_Exist()
        {
            #region Prepare
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\asdasd\\file.json";
            string[] args = new string[] { path, "1" };
            #endregion

            #region Act
            var error = _argumentProcessor.CheckFile(ref args);
            #endregion

            #region Assert
            Assert.NotNull(error);
            #endregion
        }

        /// <summary>
        /// We are checking if there will be any errors if the supplied string
        /// is actually a valid path, we supplied a wrong path, we expect to return error
        /// </summary>
        [Fact]
        public void Check_File_Is_A_Directory()
        {
            #region Prepare
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string[] args = new string[] { path, "1" };
            #endregion

            #region Act
            var error = _argumentProcessor.CheckFile(ref args);
            #endregion

            #region Assert
            Assert.NotNull(error);
            #endregion
        }

    }
}
