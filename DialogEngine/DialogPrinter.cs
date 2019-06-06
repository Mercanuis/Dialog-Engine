using System;

namespace DialogEngine
{
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
