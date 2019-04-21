using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSV2.Model.Models;

namespace WSV2.Program.Model
{
    /// <summary>
    /// Client facing object that we will receieve through json file
    /// </summary>
    public class InputObject
    {
        /// <summary>
        /// List of Entities from json file
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "entities")]
        public List<Entity> Entities { get; set; }

        /// <summary>
        /// List of Links from json file
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "links")]
        public List<Link> Links { get; set; }
    }
}
