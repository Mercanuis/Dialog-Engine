using System;

namespace Errors
{
    public class UtilityException : Exception
    {
        private const string ERROR_MSG = "UtilityException";

        /// <summary>
        /// Generic Constructor for UtilError
        /// </summary>
        public UtilityException()
        {
        }

        public UtilityException(string message)
            : base(String.Format("{0}: {1}", ERROR_MSG, message))
        {
        }
    }
}
