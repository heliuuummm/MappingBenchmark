﻿using Mapster;
using System;

namespace MappingBenchmark.Domain
{
    [AdaptTo("[name]CodeGenTo"), GenerateMapper]
    public class ProductVariant
    {
        public Guid Id { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }
    }
}
