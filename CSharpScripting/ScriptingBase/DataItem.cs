using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptingBase
{
    public class DataItem
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        
        public DataItem()
        {
            Init();
        }

        private void Init()
        {
            X = 1;
            Y = 1;
            Name = nameof(DataItem);
            Time = DateTime.Now;
        }

        public void Reset()
        {
            Init();
        }

        public override string ToString()
        {
            return $"{nameof(DataItem)}: {{ X = {X}, Y = {Y}, Name = {Name}, Time = {Time} }}";
        }
    }
}
