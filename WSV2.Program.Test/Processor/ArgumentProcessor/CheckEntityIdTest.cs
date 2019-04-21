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
    public class CheckEntityIdTest
    {
        /// <summary>
        /// ArgumentProcessor
        /// </summary>
        private readonly WSV2.Program.Processor.ArgumentProcessor _argumentProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public CheckEntityIdTest()
        {
            var fileProcessor = new FileProcessor();
            _argumentProcessor = new WSV2.Program.Processor.ArgumentProcessor(fileProcessor);
        }

        /// <summary>
        /// We are checking if there will be any errors if the supplied string
        /// can be parsed as long, we expect that function will return null
        /// </summary>
        [Fact]
        public void Check_Entity_Id_Long()
        {
            #region Prepare
            string entityId = "1";
            #endregion

            #region Act
            var error = _argumentProcessor.CheckEntityId(entityId);
            #endregion

            #region Assert
            Assert.Null(error);
            #endregion
        }

        /// <summary>
        /// We are checking if there will be any errors if the supplied string
        /// can be parsed as long, we expect that function will return error
        /// </summary>
        [Fact]
        public void Check_Entity_Id_String()
        {
            #region Prepare
            string entityId = "some string";
            #endregion

            #region Act
            var error = _argumentProcessor.CheckEntityId(entityId);
            #endregion

            #region Assert
            Assert.NotNull(error);
            #endregion
        }
    }
}
