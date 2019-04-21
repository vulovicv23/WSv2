using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSV2.Model.Models
{
    public class Link
    {
        /// <summary>
        /// Entity ID that links FROM
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "from")]
        public long FromEntityId { get; set; }

        /// <summary>
        /// Entity ID that links TO
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "to")]
        public long ToEntityId { get; set; }
    }
}
