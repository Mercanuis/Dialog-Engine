using System;
using System.Collections.Generic;

namespace DialogEngine.Printers.Custom
{
    /// <summary> Class CustomPrinter is for the printing of dialog that requires "Custom" parameters.
    /// <para>
    /// This class is meant to help with a variety of non-specified cases. Such as system dialog or dialog that can be used in a variety of scenarios
    /// For example, a battle engine would be able to instantiate a printer that allows the engine to take in parameters (names, damage numbers, etc)
    /// and then use specified dialog to format the parameters correctly. 
    /// </para>
    /// </summary>
    class CustomPrinter : AbstractDialogPrinter
    {
        private readonly Dictionary<int, string> dialogMap;

        public CustomPrinter(Queue<string> lines)
        {
            dialogMap = new Dictionary<int, string>();
            int i = 0;
            foreach(string line in lines)
            {
                dialogMap.Add(i, line);
                i++;
            }
        }

        public override string GetDialogLine()
        {
            return dialogMap[0];
        }

        public override string GetDialogLine(int index)
        {
            return dialogMap[index];
        }
    }
}
