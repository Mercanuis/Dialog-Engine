using System;
using System.Collections.Generic;
using System.Text;

namespace DialogEngine
{
    /// <summary>
    /// Class DialogMap is a object representing a sorted dictionary of <c>Line</c>
    /// </summary>
    public class DialogMap
    {
        private readonly SortedDictionary<int, Line> map;
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
}
