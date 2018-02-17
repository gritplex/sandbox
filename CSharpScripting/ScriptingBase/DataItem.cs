using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ScriptingBase
{
    public class DataItem
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public int CancellationTimeout { get; set; }
        public CancellationToken CancellationToken { get; set; }
        public bool IsCanceled => CancellationToken.IsCancellationRequested;

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
            CancellationTimeout = 15000;
        }


        public void Reset()
        {
            Init();
        }

        public override string ToString()
        {
            return $"{nameof(DataItem)}: {{ {nameof(X)} = {X}, {nameof(Y)} = {Y}, {nameof(Name)} = {Name}, {nameof(Time)} = {Time}, {nameof(CancellationTimeout)} = {CancellationTimeout}ms }}";
        }
    }
}
