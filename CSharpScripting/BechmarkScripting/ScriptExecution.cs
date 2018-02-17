using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis.Scripting;
using ScriptingBase;

namespace BechmarkScripting
{
    public class ScriptExecution
    {
        private CompileTimeDefined _compileTime;
        private ScriptRunner<object> _script;

        private DataItem _scriptDataItem;
        private DataItem _compileTimeDataItem;

        private const string _scriptCode = @"
            unchecked
            {
                X++;
                Y++;
                Name = $""{X + Y}"";
                Time = System.DateTime.Now;
            }
";

        public ScriptExecution()
        {
            _compileTimeDataItem = new DataItem();
            _scriptDataItem = new DataItem();

            _compileTime = new CompileTimeDefined
            {
                Item = _compileTimeDataItem
            };

            var scriptProvider = new ScriptingBase.Script();
            _script = scriptProvider.CreateScriptDelegate(_scriptCode, typeof(DataItem));            
        }

        [Benchmark]
        public void RunScript()
        {
            _script.Invoke(_scriptDataItem);
        }

        [Benchmark]
        public void RunCompileTime()
        {
            _compileTime.Run();
        }
    }

    public class CompileTimeDefined
    {        
        public DataItem Item;
        
        public void Run()
        {
            unchecked
            {
                Item.X++;
                Item.Y++;
                Item.Name = $"{Item.X + Item.Y}";
                Item.Time = DateTime.Now;
            }
        }
    }
}
