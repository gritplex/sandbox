using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting.Hosting;

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

        public async Task<object> ExecuteAsync(string expression)
        {
            object result;

            try
            {
                result = await CSharpScript.EvaluateAsync(expression);
            }
            catch (Exception e)
            {
                result = e;                
            }

            return result;
        }
    }
}
