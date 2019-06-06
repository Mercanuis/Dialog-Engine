using System.Collections.Generic;
using System.IO;

namespace DialogEngine
{
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

    public class DialogMap
    {
        private SortedDictionary<int, Line> map;
        private int counter;

        public DialogMap()
        {
            map = new SortedDictionary<int, Line>() { };
            counter = 0;
        }

        public void AddToMap(string actor, string dialog)
        {
            map.Add(counter, new Line(actor, dialog));
            counter++;
        }

        public int GetCount()
        {
            return map.Count;
        }

        public Line GetByKey(int key)
        {
            return map[key];
        }
    }

    public class DialogGenerator
    {
        private const char SEPARATOR = ':';

        private readonly DialogMap dialogMap;
        private readonly string scenePath;

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
                //Do something bad here later
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
