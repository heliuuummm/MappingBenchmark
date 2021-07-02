using System;
using System.Collections.Generic;
using MappingBenchmark.Domain;

namespace MappingBenchmark.Domain
{
    public partial class ProductCodeGenDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public List<ProductVariantCodeGenDto> Options { get; set; }
        public ProductVariantCodeGenDto DefaultOption { get; set; }
    }
}