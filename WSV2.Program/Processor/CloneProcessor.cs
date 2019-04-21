using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Common.Exception;
using WSV2.Common.IO;
using WSV2.Model.Models;
using WSV2.Program.Model;

namespace WSV2.Program.Processor
{
    /// <summary>
    /// This class will hold the core funcionality for the app.
    /// Basically, it will do creating new entities and links, cloning and at the end
    /// returning json result back.
    /// </summary>
    public class CloneProcessor : ICloneProcessor
    {
        /// <summary>
        /// IJsonProcessor for using methods concerning Json manipulation
        /// </summary>
        private readonly IJsonProcessor _jsonProcessor;

        /// <summary>
        /// IInputObjectProcessor for using methods concerning InputObject manipulation
        /// </summary>
        private readonly IInputObjectProcessor _inputObjectProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="inputObjectProcessor">Instance of IInputObjectProcessor</param>
        /// <param name="jsonProcessor">Instance of IJsonProcessor</param>
        public CloneProcessor(IInputObjectProcessor inputObjectProcessor, IJsonProcessor jsonProcessor)
        {
            _inputObjectProcessor = inputObjectProcessor;
            _jsonProcessor = jsonProcessor;
        }

        /// <summary>
        /// Handle the main logic for cloning json file and creating the core funcionality
        /// </summary>
        /// <param name="args">Arguments passed through command line</param>
        /// <returns>Json string when the whole process is done</returns>
        public string DoCloning(string[] args)
        {
            // Create concrete objects for arguments so they can be used further down the code
            string filePath = args[0];
            long entityId = long.Parse(args[1]);

            // Deserialize from file into our InputObject
            InputObject inputObject = _jsonProcessor.DeserializeFromPath<InputObject>(args[0]);

            // Sort all entities by its ID, this will be used for generating new IDs
            _inputObjectProcessor.SortEntities(inputObject);

            // Get initial Entity
            Entity initialEntity = GetInitialEntity(inputObject, entityId);

            // Clone InitialEntity and add to the list
            Entity initialClone = CreateCloneAndAssignId(inputObject, initialEntity);

            HandleAllTo(inputObject, initialEntity, initialClone);
            HandleAllFrom(inputObject, initialEntity, initialClone);

            // Serialize object to json string with indents and null handling
            string result = _jsonProcessor.SerialzeWithIndent(inputObject);

            return result;
        }

        /// <summary>
        /// Gets the Entity for the entity_id supplied by json
        /// </summary>
        /// <param name="inputObject">Input Object from the json file</param>
        /// <param name="entityId">Id supplied in the arguments</param>
        /// <returns>Entity object from the json file</returns>
        public Entity GetInitialEntity(InputObject inputObject, long entityId)
        {
            // Get the initial Entity from the arguments
            Entity initialEntity = inputObject.Entities.Where(w => w.ID == entityId).FirstOrDefault();

            // Check if initial Entity exist, if not, throw error
            if (initialEntity == null)
                throw new RootObjectNotFound($"Entity with id {entityId} not found");

            return initialEntity;
        }

        /// <summary>
        /// Create a clone of the Entity object, assign new ID and add it to the InputObject
        /// </summary>
        /// <param name="inputObject">Input Object from the json file</param>
        /// <param name="original">Original Entity that should be cloned</param>
        /// <returns>Cloned object</returns>
        public Entity CreateCloneAndAssignId(InputObject inputObject, Entity original)
        {
            // Create copy, assign new ID and add it to the list of entities
            Entity clone = (Entity)original.Clone();
            clone.ID = inputObject.Entities.LastOrDefault().ID + 1;

            inputObject.Entities.Add(clone);

            return clone;
        }

        /// <summary>
        /// Handle all links that have InitialEntity as TO ID.
        /// </summary>
        /// <param name="inputObject">Input Object from the json file</param>
        /// <param name="initialEntity">InitialEntity gotten from the passed argument ID</param>
        /// <param name="initialCopy">InitialEntity Copy created as first step with new ID</param>
        public void HandleAllTo(InputObject inputObject, Entity initialEntity, Entity initialCopy)
        {
            // Get all links for InitialEntity's ID where its ID is in TO field in links array
            var toList = inputObject.Links.Where(w => w.ToEntityId == initialEntity.ID).ToList();

            // Itterate over the enumerable and copy for new ID
            foreach (var to in toList)
            {
                inputObject.Links.Add(CreateLinkForObjects(to.FromEntityId, initialCopy.ID));
            }
        }

        /// <summary>
        /// Hanlde all links that have InitialEntity as FROM ID.
        /// </summary>
        /// <param name="inputObject">Input Object from the json file</param>
        /// <param name="initialEntity">InitialEntity which for which we are finding FROM ID</param>
        /// <param name="initialCopy">InitialEntity Copy created from the InitialEntity and assgined new ID</param>
        public void HandleAllFrom(InputObject inputObject, Entity initialEntity, Entity initialCopy)
        {
            // Get all links for InitialEntity's ID where its ID is in FROM field in links array
            var fromList = inputObject.Links.Where(w => w.FromEntityId == initialEntity.ID).ToList();

            // Itterate over the enumerable and copy for new ID
            foreach (var from in fromList)
            {
                Entity linkedEntity = inputObject.Entities.Where(w => w.ID == from.ToEntityId).FirstOrDefault();
                Entity linkedCopy = CreateCloneAndAssignId(inputObject, linkedEntity);

                inputObject.Links.Add(CreateLinkForObjects(initialCopy.ID, linkedCopy.ID));

                // Itterate again so we can find all links that link back to original entity
                HandleAllFrom(inputObject, linkedEntity, linkedCopy);
            }
        }

        /// <summary>
        /// Create new Link from from and to IDs 
        /// </summary>
        /// <param name="from">ID of the from Entity</param>
        /// <param name="to">ID of the to Entity</param>
        /// <returns>New Link Object</returns>
        public Link CreateLinkForObjects(long from, long to)
        {
            Link link = new Link
            {
                FromEntityId = from,
                ToEntityId = to
            };

            return link;
        }
    }
}
