using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting.Hosting;
using Microsoft.CodeAnalysis.Scripting;

namespace ScriptingBase
{
    /*
        This is a test class for getting familiar with the Scripting API offered by Roslyn.
        Test things here!
    */

    public class Script
    {
        public string Format(object obj)
        {
            switch (obj)
            {
                case Exception e:
                    return CSharpObjectFormatter.Instance.FormatException(e);
                default:
                    return CSharpObjectFormatter.Instance.FormatObject(obj);
            }
        }

        public ScriptRunner<object> CreateScriptDelegate(string expression, Type globalType)
        {
            Script<object> script = CSharpScript.Create(expression, globalsType: globalType);
            script.Compile();
            return script.CreateDelegate();
        }

        private async Task<object> ExecuteInternalAsync(string expression, object global = null, CancellationToken cancellation = default)
        {
            object result;

            try
            {
                if (global == null)
                {
                    result = await CSharpScript.EvaluateAsync(expression, cancellationToken: cancellation);
                }
                else
                {
                    result = await CSharpScript.EvaluateAsync(expression, globals: global, cancellationToken: cancellation);
                }
            }
            catch (Exception e)
            {
                result = e;
            }

            return result;
        }

        public Task<object> ExecuteAsync(string expression, CancellationToken cancellation = default)
        {
            return ExecuteInternalAsync(expression, cancellation: cancellation);
        }

        public Task<object> ExecuteWithGlobalAsync(string expression, object global, CancellationToken cancellation = default)
        {
            return ExecuteInternalAsync(expression, global, cancellation);
        }
    }
}
