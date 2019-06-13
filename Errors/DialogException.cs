using System;

namespace Errors
{
    class DialogException : Exception
    {
        private const string ERROR_MSG = "DialogException";

        public DialogException()
        {
        }

        public DialogException(string message)
            : base(String.Format("{0}:{1}", ERROR_MSG, message))
        {
        }

        public DialogException(string message, Exception inner)
            : base(String.Format("{0}:{1}", ERROR_MSG, message), inner)
        {
        }

        static void Main()
        {
        }
    }

    class ScriptNotFoundException : DialogException
    {
        private const string SCRIPT_NOT_FOUND = "The following script could not be found";

        public ScriptNotFoundException(string filePath) 
            : base(String.Format("{0}:{1}", SCRIPT_NOT_FOUND, filePath))
        {
        }
    }
}
