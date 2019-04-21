using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Program.Model;

namespace WSV2.Program.Processor
{
    /// <summary>
    /// 
    /// </summary>
    public class InputObjectProcessor : IInputObjectProcessor
    {

        /// <summary>
        /// Sorts Input Object Entities by ID
        /// </summary>
        /// <param name="inputObject">Input Object gotten from json file</param>
        public void SortEntities(InputObject inputObject)
        {
            inputObject.Entities.Sort((x, y) => x.ID.CompareTo(y.ID));
        }
    }
}
