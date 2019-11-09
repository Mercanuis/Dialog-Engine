using Errors;
namespace DialogEngine.Utilities
{
    class Utilities
    {

    }

    class DialogConstants
    {
        public const string GENERAL_PRINTER = "General";
        public const string REPEATING_PRINTER = "Repeating";
        public const string BATTLE_PRINTER = "Battle";

        public static string GetPrinterType(string fileLine)
        {
            //Determine the type from the pattern [DIALOG_TYPE=]?[a-zA-Z]+
            if (fileLine.Contains(GENERAL_PRINTER))
            {
                return GENERAL_PRINTER;
            }
            else if (fileLine.Contains(REPEATING_PRINTER))
            {
                return REPEATING_PRINTER;
            }
            else if (fileLine.Contains(BATTLE_PRINTER))
            {
                return BATTLE_PRINTER;
            }

            throw new UtilErrors("File type was not found");
        }
    }
}
