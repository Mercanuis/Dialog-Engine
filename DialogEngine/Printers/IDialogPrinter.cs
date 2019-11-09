namespace DialogEngine.Printers
{
    /// <summary>
    /// Defines a set of functions to be used for access to any Printers.
    /// </summary>
    public interface IDialogPrinter
    {
        /// <summary>
        /// Retrieve the next line of Dialog from the Printer
        /// </summary>
        /// <returns>The next line of dialog, in string format</returns>
        string GetDialogLine();

        string GetDialogLine(int index);
    }
}
