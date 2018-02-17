using ScriptingBase;
using System;
using System.Threading.Tasks;

namespace ConsoleTestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var scriptExecuter = new Script();
            string input = "";
            bool quitRequested = false;

            Console.WriteLine("Type an expression to be evaluated or 'quit' to exit.");
            do
            {
                input = Console.ReadLine();
                quitRequested = string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase);
                if (!quitRequested)
                {
                    object result = await scriptExecuter.ExecuteAsync(input);
                    Console.WriteLine(scriptExecuter.Format(result));
                }
            } while (!quitRequested);
        }
    }
}
