using System.Collections.Generic;
using System.IO;
using Errors;
using DialogEngine.Utilities;

/// <summary>
/// Namespace related to anything involving the generation, management, and production of 
/// dialog in the system. 
/// </summary>
namespace DialogEngine
{
    /// <summary>
    /// Class <code>DialogGenerator</code> is used to fetch, tokenize, and generate a map of dialog 
    /// to be used by a <code>DialogPrinter</code>. 
    /// </summary>
    class DialogGenerator
    {
        private readonly string scenePath;
        private readonly Queue<string> lines;
        private string printerType;

        /// <summary>
        /// Create a new instance of a DialogGenerator
        /// </summary>
        /// <param name="scenePath">File path, in string format of the scene to generate</param>
        public DialogGenerator(string scenePath)
        {
            this.scenePath = scenePath;

            lines = new Queue<string>() { };
            GenerateDialogMap();
        }

        private void GenerateDialogMap()
        {
            if (!File.Exists(scenePath))
            {
                throw new ScriptNotFoundException(scenePath);
            }

            using (StreamReader sr = File.OpenText(scenePath))
            {
                //Read the first line as its the type dileniator, then enqueue the rest of the lines
                //TODO: Is this the best way to determine file type and to generalize the manager/printer interactions?
                string line;
                line = sr.ReadLine();
                printerType = DialogConstants.GetPrinterType(line);

                while ((line = sr.ReadLine()) != null)
                {
                    lines.Enqueue(line);
                }
            }
        }

        /// <summary>
        /// Returns the resulted generated dialog
        /// </summary>
        /// <returns>Generated dialog in a queue</returns>
        public Queue<string> GetLines()
        {
            return lines;
        }

        public string GetPrinterType()
        {
            return printerType;
        }
    }
}
