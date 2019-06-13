using System;

namespace DialogEngine
{
    /// <summary> Class DialogPrinter is repsonsible for the printing of dialog for a scene
    /// <para>
    /// It takes a dialog map created by the <code>DialogGenerator</code> and tracks
    /// the current point in time at the script the game or user is at. This allows a 'decoupling'
    /// of creating the script, and how it's handled once generated. 
    /// </para>
    /// </summary>
    public class DialogPrinter
    {
        private const int END_OF_DIALOG = -1;
        private const string END = "____END____";

        private readonly DialogMap dialogMap;
        private int counter;

        public DialogPrinter(DialogMap map)
        {
            dialogMap = map;
            counter = 0;
        }

        /// <summary>
        /// Fetch the next line of dialog the printer has
        /// </summary>
        /// <returns>The next line of dialog in a formatted string, or special case END</returns>
        public string GetNextDialogLine()
        {
            if (counter != END_OF_DIALOG)
            {
                Line dialogLine = dialogMap.GetByKey(counter);
                String ret = String.Format("{0}: {1}", dialogLine.Actor, dialogLine.Dialog);

                counter++;
                if (counter >= dialogMap.GetCount())
                {
                    counter = END_OF_DIALOG;
                }
                return ret;
            }

            return END;
        }
    }
}
