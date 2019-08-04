using System;
using System.Collections.Generic;
using System.Text;
using Errors;

/// <summary>
/// Manager class for the Dialog namespace. Most if not all calls should be made through this class
/// </summary>
namespace DialogEngine
{
    public class DialogManager
    {
        public DialogManager()
        {

        }

        /// <summary>
        /// Retrieves the script for the given file path
        /// </summary>
        /// <param name="filePath">string filepath to a vaild file</param>
        /// <returns>DialogPrinter if the script is found and processed, null otherwise</returns>
        public DialogPrinter GetForScript(string filePath)
        {
            DialogPrinter printer = null;
            try
            {
                DialogGenerator gen = new DialogGenerator(filePath);
                printer = new DialogPrinter(gen.GetLines());
            } catch (ScriptNotFoundException e)
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
