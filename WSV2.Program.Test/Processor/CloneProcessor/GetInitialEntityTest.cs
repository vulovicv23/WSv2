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
    public class GetInitialEntityTest
    {
        /// <summary>
        /// CloneProcessor
        /// </summary>
        protected readonly WSV2.Program.Processor.CloneProcessor _cloneProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        public GetInitialEntityTest()
        {
            var inputObjectProcessor = new WSV2.Program.Processor.InputObjectProcessor();
            var fileProcessor = new FileProcessor();
            var jsonProcessor = new JsonProcessor(fileProcessor);
            _cloneProcessor = new Program.Processor.CloneProcessor(inputObjectProcessor, jsonProcessor);
        }

        /// <summary>
        /// We want to return entity if there is an entity with that id in the
        /// InputObject, we expect that entity will be null
        /// </summary>
        [Fact]
        public void Entity_Doesnt_Exist_Flow()
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

            var entityId = 99;
            #endregion

            #region Assert
            Assert.Throws<RootObjectNotFound>(() => _cloneProcessor.GetInitialEntity(inputObject, entityId));
            #endregion
        }

        /// <summary>
        /// We want to return entity if there is an entity with that id in the
        /// InputObject, we expect that entity will not be null
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

            var entityId = 1;
            #endregion

            #region Act
            var entity = _cloneProcessor.GetInitialEntity(inputObject, entityId);
            #endregion

            #region Assert
            Assert.NotNull(entity);
            #endregion
        }
    }
}
