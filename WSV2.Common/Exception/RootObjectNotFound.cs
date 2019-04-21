using System;
using System.Collections.Generic;
using System.Text;

namespace WSV2.Common.Exception
{
    /// <summary>
    ///  Class used to throw errors when there is no object found for specified condition
    /// </summary>
    public class RootObjectNotFound : System.Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to be passed as error messag</param>
        public RootObjectNotFound(string message)
            : base(message)
        {

        }
    }
}
