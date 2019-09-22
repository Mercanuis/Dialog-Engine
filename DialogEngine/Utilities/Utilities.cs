using System;
using System.Collections.Generic;
using System.Text;

namespace DialogEngine.Utilities
{
    class Utilities
    {

    }

    class DialogConstants
    {
        public const string GENERAL_PRINTER = "General";
        public const string REPEATING_PRINTER = "Repeating";

        public static string GetPrinterType(string fileLine)
        {
            //Determine the type from the pattern [DIALOG_TYPE=]?[a-zA-Z]+
            if(fileLine.Contains(GENERAL_PRINTER))
            {
                return GENERAL_PRINTER;
            }
            else if (fileLine.Contains(REPEATING_PRINTER))
            {
                return REPEATING_PRINTER;
            }

            //for now, return general.
            //TODO: error handling? determine if necessary
            return GENERAL_PRINTER;
        }
    }
}
