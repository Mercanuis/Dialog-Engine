using DialogEngine.Printers;
using DialogEngine.Printers.Custom;
using DialogEngine.Utilities;
using Errors;
using System;

/// <summary>
/// Manager class for the Dialog namespace. Most if not all calls should be made through this class
/// </summary>
namespace DialogEngine
{
    public class DialogManager
    {
        private const string GENERAL = DialogConstants.GENERAL_PRINTER;
        private const string REPEATING = DialogConstants.REPEATING_PRINTER;
        private const string BATTLE = DialogConstants.BATTLE_PRINTER;

        public DialogManager()
        {

        }

        /// <summary>
        /// Retrieves the script for the given file path
        /// </summary>
        /// <param name="filePath">string filepath to a vaild file</param>
        /// <returns>DialogPrinter if the script is found and processed, null otherwise</returns>
        public IDialogPrinter GetForScript(string filePath)
        {
            IDialogPrinter printer = null;
            try
            {
                DialogGenerator gen = new DialogGenerator(filePath);

                switch (gen.GetPrinterType())
                {
                    case GENERAL:
                        printer = new DialogPrinter(gen.GetLines());
                        break;
                    case REPEATING:
                        printer = new RepeatingPrinter(gen.GetLines());
                        break;
                    case BATTLE:
                        printer = new BattlePrinter(gen.GetLines());
                        break;
                }
            }
            catch (ScriptNotFoundException e)
            {
                Console.Out.WriteLine(e.Message);
            }

            return printer;
        }

        //For compilation
        public static void Main()
        { }
    }
}
