using System.Collections.Generic;
using System.IO;
using Errors;

/// <summary>
/// Namespace related to anything involving the generation, management, and production of 
/// dialog in the system. 
/// </summary>
namespace DialogEngine
{
    /// <summary>
    /// A Line is an underlying object that is used to assemble the dialog for a scene
    /// A Line is a simple object containing the actor and the line of script to say
    /// </summary>
    public struct Line
    {
        public Line(string act, string dia)
        {
            Actor = act;
            Dialog = dia;
        }

        public string Actor { get; }
        public string Dialog { get; }
    }

    /// <summary>
    /// Class <code>DialogGenerator</code> is used to fetch, tokenize, and generate a map of dialog 
    /// to be used by a <code>DialogPrinter</code>. 
    /// </summary>
    public class DialogGenerator
    {
        private const char SEPARATOR = ':';

        private readonly DialogMap dialogMap;
        private readonly string scenePath;

        /// <summary>
        /// Create a new instance of a DialogGenerator
        /// </summary>
        /// <param name="scenePath">File path, in string format of the scene to generate</param>
        public DialogGenerator(string scenePath)
        {
            dialogMap = new DialogMap();
            this.scenePath = scenePath;
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
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] tokens = line.Split(SEPARATOR);
                    dialogMap.AddToMap(tokens[0].Trim(), tokens[1].Trim());
                }
            }
        }

        /// <summary>
        /// Fetch the DialogMap generated
        /// </summary>
        /// <returns>The <code>DialogMap</code> object</returns>
        public DialogMap GetDialog()
        {
            return dialogMap;
        }

        public static void Main()
        {
            //do nothing
        }
    }
}
