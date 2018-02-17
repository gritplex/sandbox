using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace BechmarkScripting
{
    public static class Benchmarks
    {
        public static Task Run()
        {
            Summary summary = BenchmarkRunner.Run<ScriptExecution>();
            Console.WriteLine($"{Environment.NewLine} Press any key to go back to the main menu.");
            Console.Read();
            return Task.CompletedTask;
        }
    }
}
