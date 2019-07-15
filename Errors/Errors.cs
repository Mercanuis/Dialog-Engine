using System;

/// <summary>
/// Namespace concerned with handling and directives for errors in the dialog engine
/// This namespace could expand as the project grows (errors for game, errors for dialog, errors for sprites, etc)
/// Extend Exception as a base to allow for custom exceptions as necessary. 
/// </summary>
namespace Errors
{
    /// <summary>
    /// Class DialogExcpetion is a general exception related to anything related to the dialog
    /// Such examples could be a script not being found, or a particular token generation error
    /// but these might be best to be handled in specified exceptions that are based off the 
    /// namespace
    /// </summary>
    public class DialogException : Exception
    {
        private const string ERROR_MSG = "DialogException";

        /// <summary>
        /// Generic Constructor for DialogException
        /// </summary>
        public DialogException()
        {
        }

        /// <summary>
        /// Generates a <c>DialogException</c> with the passed in message
        /// </summary>
        /// <param name="message">message to format</param>
        public DialogException(string message)
            : base(String.Format("{0}: {1}", ERROR_MSG, message))
        {
        }

        /// <summary>
        /// Generates a <c>DialogException</c> with formatted message and inner <c>Exception</c>
        /// </summary>
        /// <param name="message">message to format</param>
        /// <param name="inner">the inner <c>Exception</c></param>
        public DialogException(string message, Exception inner)
            : base(String.Format("{0}: {1}", ERROR_MSG, message), inner)
        {
        }

        static void Main()
        {
        }
    }

    /// <summary>
    /// ScriptNotFoundException to throw when specified script file cannot be found
    /// </summary>
    public class ScriptNotFoundException : DialogException
    {
        private const string SCRIPT_NOT_FOUND = "The following script could not be found";

        /// <summary>
        /// Create a <c>ScriptNotFoundException</c> with the passed in file path
        /// </summary>
        /// <param name="filePath">file path attempted to be used, in string format</param>
        public ScriptNotFoundException(string filePath)
            : base(String.Format("{0}: {1}", SCRIPT_NOT_FOUND, filePath))
        {
        }
    }
}