using System;
using System.Collections.Generic;
using System.Text;

namespace DialogEngine.Printers
{
    /// <summary> Class RepeatingPrinter is repsonsible for the printing of dialog for a scene
    /// <para>
    /// A RepeatingPrinter "repeats" the same dialog line (or lines) over and over again, until the printer is no longer in use. Possible use cases are
    /// <list type="bullet">
    /// <item><description>An NPC that has only 1-2 lines and only needs to ever say them</description></item>
    /// <item><description>A sort of system dialog that is common and should be used/seen multiple times</description></item>
    /// </list>
    /// </para>
    /// </summary>
    class RepeatingPrinter : AbstractDialogPrinter
    {
        private readonly List<string> dialogList;
        private int currentLine = 0;

        public RepeatingPrinter(Queue<string> lines)
        {
            string[] dialoges = lines.ToArray();
            dialogList = new List<string>() { };
            foreach (string line in dialoges)
            {
                dialogList.Add(line);
            }
        }

        public override string GetDialogLine()
        {
            if (currentLine >= dialogList.Count)
            {
                currentLine = 0;
            }

            string nextLine = dialogList[currentLine];
            currentLine++;
            return nextLine;
        }
    }
}
