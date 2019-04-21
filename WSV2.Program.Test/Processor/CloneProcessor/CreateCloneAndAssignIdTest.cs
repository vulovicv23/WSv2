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
    public class CreateCloneAndAssignIdTest
    {
        /// <summary>
        /// CloneProcessor
        /// </summary>
        protected readonly WSV2.Program.Processor.CloneProcessor _cloneProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateCloneAndAssignIdTest()
        {
            var inputObjectProcessor = new WSV2.Program.Processor.InputObjectProcessor();
            var fileProcessor = new FileProcessor();
            var jsonProcessor = new JsonProcessor(fileProcessor);
            _cloneProcessor = new Program.Processor.CloneProcessor(inputObjectProcessor, jsonProcessor);
        }

        /// <summary>
        /// We want to clone the original object and to assign new Id,
        /// we expect that the entity will not be null, will have Id bigger by 1 than
        /// the last element's id and that the list of entities is larger for 1
        /// </summary>
        [Fact]
        public void Entity_Exist_Flow()
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
                }
            };

            var originalEntity = inputObject.Entities.ElementAt(1);
            #endregion

            #region Act
            var entity = _cloneProcessor.CreateCloneAndAssignId(inputObject, originalEntity);
            #endregion

            #region Assert
            Assert.NotNull(entity);
            Assert.Equal(4, entity.ID);
            Assert.Equal(4, inputObject.Entities.Count);
            #endregion
        }
    }
}
