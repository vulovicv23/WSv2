using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Common.IO;
using WSV2.Model.Models;
using WSV2.Program.Model;
using WSV2.Program.Processor;
using Xunit;

namespace WSV2.Program.Test.Processor.InputObjectProcessor
{
    public class SortEntitiesTest
    {
        /// <summary>
        /// IInputObjectProcessor
        /// </summary>
        private readonly IInputObjectProcessor _inputObjectProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public SortEntitiesTest()
        {
            _inputObjectProcessor = new WSV2.Program.Processor.InputObjectProcessor();
        }

        /// <summary>
        /// We want to make sure that the passed object is being sorted correctly
        /// so for this test, we want to assert that sorting works
        /// </summary>
        [Fact]
        public void Check_Sorting_Works()
        {
            #region Prepare
            var inputObject = new InputObject()
            {
                Entities = new List<Entity>()
                {
                    new Entity()
                    {
                        ID = 1
                    },
                    new Entity()
                    {
                        ID = 3
                    },
                    new Entity()
                    {
                        ID = 2
                    },
                }
            };
            #endregion

            #region Act
            _inputObjectProcessor.SortEntities(inputObject);
            #endregion

            #region Assert
            for (int i = 1; i <= inputObject.Entities.Count; i++)
            {
                Assert.Equal(i, inputObject.Entities.ElementAt(i - 1).ID);
            }
            #endregion
        }

    }
}
