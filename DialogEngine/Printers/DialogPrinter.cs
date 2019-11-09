using System.Collections.Generic;

namespace DialogEngine.Printers
{
    /// <summary> Class DialogPrinter is repsonsible for the printing of dialog for a scene.  This allows a 'decoupling' of creating the script, and how it's handled once generated. 
    /// <para>
    /// DialogPrinter is a 'default' option that is meant to facilitate a normal dialog that is used once, and is never brought up again. Some examples could be
    /// <list type="bullet">
    /// <item><description>A dialog in a story scene</description></item>
    /// <item><description>A one-time system dialog</description></item>
    /// </list>
    /// </para>
    /// </summary>
    class DialogPrinter : AbstractDialogPrinter
    {
        private const string END = "____END____";

        private readonly Queue<string> dialogLines;

        public DialogPrinter(Queue<string> lines)
        {
            dialogLines = lines;
        }

        public override string GetDialogLine()
        {
            if (dialogLines.TryDequeue(out string line))
            {
                return line;
            }

            return END;
        }
    }
}
