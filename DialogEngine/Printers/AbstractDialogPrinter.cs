using System;
using System.Collections.Generic;
using System.Text;

namespace DialogEngine.Printers
{
    internal abstract class AbstractDialogPrinter : IDialogPrinter
    {
        public virtual string GetDialogLine()
        {
            return "";
        }

        public virtual string GetDialogLine(int index)
        {
            return "";
        }
    }
}
