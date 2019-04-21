using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSV2.Model.Models
{
    public class Entity : ICloneable
    {
        /// <summary>
        /// Entity Id
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "entity_id")]
        public long ID { get; set; }

        /// <summary>
        /// Entity Name
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Entity Description, can be null
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
