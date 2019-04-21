

namespace WSV2.Common.Exception
{
    /// <summary>
    /// Class used to throw errors regarding input arguments in the command line
    /// </summary>
    public class InvalidArgumentExcpetion : System.Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to be passed as error messag</param>
        public InvalidArgumentExcpetion(string message)
            : base(message)
        {

        }
    }
}
