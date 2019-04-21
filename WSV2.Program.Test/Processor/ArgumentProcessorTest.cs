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

namespace WSV2.Program.Test.Processor
{
    public class ArgumentProcessorTest
    {
        private readonly Mock<IArgumentProcessor> _mockArgumentExceptionProcessor;

        public ArgumentProcessorTest()
        {
            _mockArgumentExceptionProcessor = new Mock<IArgumentProcessor>();
        }

        [Fact]
        public void Test_Happy_Flow()
        {
            //#region Prepare
            //var fileProcessor = new FileProcessor();

            //// Entity Id which is actually a number
            //string entityId = "1";
            //// Path for existing file
            //string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\file.json";

            //// Arguments that will get passed
            //string[] args = new string[] { path, entityId };

            //var argumentExceptionProcessor = new ArgumentProcessor(fileProcessor);
            //#endregion

            //#region Act
            //var errors = argumentExceptionProcessor.HandleArguments(ref args);
            //#endregion

            //#region Assert
            //Assert.Null(errors);
            //#endregion
        }
    }
}
