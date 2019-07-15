﻿using System.Collections.Generic;
using System.IO;
using Errors;

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
    public class DialogGenerator
    {
        private readonly string scenePath;
        private readonly Queue<string> lines;

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
                string line;
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
        public Queue<string> getLines()
        {
            return lines;
        }

        public static void Main()
        {
            //do nothing
        }
    }
}
