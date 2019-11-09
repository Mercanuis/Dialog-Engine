using System;
using System.Collections.Generic;
using System.Text;

namespace Errors
{
    public class UtilErrors : Exception
    {
        private const string ERROR_MSG = "UtilityException";

        /// <summary>
        /// Generic Constructor for UtilError
        /// </summary>
        public UtilErrors()
        {
        }

        public UtilErrors(string message)
            : base(String.Format("{0}: {1}", ERROR_MSG, message))
        { 
        }
    }
}
