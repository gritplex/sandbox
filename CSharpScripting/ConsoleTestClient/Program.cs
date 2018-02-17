using ScriptingBase;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTestClient
{
    class Program
    {
        private static Script _scriptExecuter = new Script();
        static async Task Main(string[] args)
        {
            do
            {
                Options option = Options.None;

                Console.Clear();
                PrintOptions();

                string input = Console.ReadLine();
                Enum.TryParse(input, true, out option);

                if (option == Options.Quit)
                {
                    return;
                }

                await DoOption(option);

            } while (true);
        }

        enum Options
        {
            None = -1,
            BasicExpression = 1,
            WithGlobal = 2,
            WithCancellation = 3,
            Quit = 99
        }

        static void PrintOptions()
        {
            Array values = Enum.GetValues(typeof(Options));
            string[] names = Enum.GetNames(typeof(Options));

            for (int i = 0; i < names.Length; i++)
            {
                var value = (int)values.GetValue(i);
                if (value > 0)
                {
                    Console.WriteLine($"[{value}] = {names[i]}");
                }
            }
        }

        static Task DoOption(Options option)
        {
            switch (option)
            {
                case Options.None:
                    break;
                case Options.BasicExpression:
                    return BasicExpression();
                case Options.WithGlobal:
                    return WithGlobal();
                case Options.WithCancellation:
                    return WithCancellation();
                case Options.Quit:
                default:
                    break;
            }
            return Task.CompletedTask;
        }

        static async Task BasicExpression()
        {
            Console.Clear();
            string input = "";
            bool quitRequested = false;
            do
            {
                Console.WriteLine("Type an expression to be evaluated or 'quit' to go back.");
                input = Console.ReadLine();
                Console.WriteLine();
                quitRequested = string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase);
                if (!quitRequested)
                {
                    Console.WriteLine($"Input: {input}");
                    object result = await _scriptExecuter.ExecuteAsync(input);
                    Console.WriteLine($"Result: {_scriptExecuter.Format(result)}");
                }
            } while (!quitRequested);
        }

        static async Task WithGlobal()
        {
            var dataItem = new DataItem();

            Console.Clear();
            string input = "";
            bool quitRequested = false;
            do
            {
                Console.WriteLine("Type an expression to be evaluated or 'quit' to go back.");
                Console.WriteLine("Current state:");
                Console.WriteLine(dataItem);
                input = Console.ReadLine();
                quitRequested = string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase);
                if (!quitRequested)
                {
                    Console.WriteLine($"Input: {input}");
                    object result = await _scriptExecuter.ExecuteWithGlobalAsync(input, dataItem);
                    Console.WriteLine($"Result: {_scriptExecuter.Format(result)}");
                    Console.WriteLine();
                }
            } while (!quitRequested);
        }

        static async Task WithCancellation()
        {
            var dataItem = new DataItem();

            Console.Clear();
            string input = "";
            bool quitRequested = false;
            do
            {
                Console.WriteLine("Type an expression to be evaluated or 'quit' to go back.");
                Console.WriteLine("Current state:");
                Console.WriteLine(dataItem);
                input = Console.ReadLine();
                quitRequested = string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase);
                if (!quitRequested)
                {
                    Console.WriteLine($"Input: {input}");

                    var cancellationSource = new CancellationTokenSource(dataItem.CancellationTimeout);
                    dataItem.CancellationToken = cancellationSource.Token;
                    object result = await _scriptExecuter.ExecuteWithGlobalAsync(input, dataItem, cancellationSource.Token);

                    Console.WriteLine($"Result: {_scriptExecuter.Format(result)}");
                    Console.WriteLine();                    
                }
            } while (!quitRequested);
        }
    }
}
