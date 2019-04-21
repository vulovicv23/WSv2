using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Common.Exception;
using WSV2.Common.IO;
using WSV2.Model.Models;
using WSV2.Program.Model;
using WSV2.Program.Processor;
using Xunit;

namespace WSV2.Program.Test.Processor.CloneProcessor
{
    public class HandleAllFromTest
    {
        /// <summary>
        /// CloneProcessor
        /// </summary>
        protected readonly WSV2.Program.Processor.CloneProcessor _cloneProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleAllFromTest()
        {
            var inputObjectProcessor = new WSV2.Program.Processor.InputObjectProcessor();
            var fileProcessor = new FileProcessor();
            var jsonProcessor = new JsonProcessor(fileProcessor);
            _cloneProcessor = new Program.Processor.CloneProcessor(inputObjectProcessor, jsonProcessor);
        }

        /// <summary>
        /// A simple test to see if the logic is alright and if we are indeed adding
        /// items to the Links list and new items to the Entity list
        /// </summary>
        [Fact]
        public void Handle_All_With_Data()
        {
            #region Prepare
            var inputObject = new InputObject()
            {
                Entities = new List<Entity>()
                {
                    new Entity()
                    {
                        ID = 1,
                        Name = "Something 1"
                    },
                    new Entity()
                    {
                        ID = 2,
                        Name = "Something 2"
                    },
                    new Entity()
                    {
                        ID = 3,
                        Name = "Something 3"
                    },
                },
                Links = new List<Link>()
                {
                    new Link()
                    {
                        FromEntityId = 1,
                        ToEntityId = 2
                    },

                    new Link()
                    {
                        FromEntityId = 1,
                        ToEntityId = 3
                    },

                    new Link()
                    {
                        FromEntityId = 2,
                        ToEntityId = 3
                    }
                }
            };

            var originalEntity = _cloneProcessor.GetInitialEntity(inputObject, 2);
            var originalEntityCopy = _cloneProcessor.CreateCloneAndAssignId(inputObject, originalEntity);
            #endregion

            #region Act
            _cloneProcessor.HandleAllFrom(inputObject, originalEntity, originalEntityCopy);
            #endregion

            #region Assert
            Assert.Equal(4, inputObject.Links.Count);
            Assert.Equal(5, inputObject.Entities.Count);
            Assert.Equal(5, inputObject.Entities.LastOrDefault().ID);
            Assert.Equal(4, inputObject.Links.LastOrDefault().FromEntityId);
            Assert.Equal(5, inputObject.Links.LastOrDefault().ToEntityId);

            #endregion
        }
    }
}
