namespace DialogEngine.Printers
{
    //TODO: Should this be public or internal
    public abstract class AbstractDialogPrinter : IDialogPrinter
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
