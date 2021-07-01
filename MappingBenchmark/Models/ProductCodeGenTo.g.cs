using System;
using System.Collections.Generic;
using MappingBenchmark.Domain;

namespace MappingBenchmark.Domain
{
    public partial class ProductCodeGenTo
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public List<ProductVariantCodeGenTo> Options { get; set; }
        public ProductVariantCodeGenTo DefaultOption { get; set; }
    }
}