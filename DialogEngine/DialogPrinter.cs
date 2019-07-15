using System.Collections.Generic;

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
        private const string END = "____END____";

        private readonly Queue<string> dialogLines;

        public DialogPrinter(Queue<string> lines)
        {
            dialogLines = lines;
        }

        /// <summary>
        /// Fetch the next line of dialog the printer has
        /// </summary>
        /// <returns>The next line of dialog in a formatted string, or special case END</returns>
        public string GetNextDialogLine()
        {
            if(dialogLines.TryDequeue(out string line))
            {
                return line;
            }

            return END;
        }
    }
}
