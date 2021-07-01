using BenchmarkDotNet.Running;
using System;

namespace MappingBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MappingBenchmark>();
        }
    }
}
