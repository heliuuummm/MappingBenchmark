using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using MappingBenchmark.Domain;
using MappingBenchmark.Dtos;

namespace MappingBenchmark
{
    [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class MappingBenchmark
    {
        [Benchmark] public ProductDto ManualMap() => MappingSamples.ManualMapSample();

        [Benchmark] public ProductDto ExpressMapper() => MappingSamples.ExpressMapperSample();

        [Benchmark] public ProductDto AutoMapper() => MappingSamples.AutoMapperSample();

        [Benchmark] public ProductDto MapsterAdapterWithoutConfig() => MappingSamples.MapsterAdapterWithoutConfigSample();

        [Benchmark] public ProductDto MapsterAdapterWithConfig() => MappingSamples.MapsterAdapterWithConfigSample();

        [Benchmark] public ProductDto MapsterAdaptToType() => MappingSamples.MapsterAdaptToTypeSample();

        [Benchmark] public ProductCodeGenDto MapsterCodeGen() => MappingSamples.MapsterCodeGenSample();
    }
}
