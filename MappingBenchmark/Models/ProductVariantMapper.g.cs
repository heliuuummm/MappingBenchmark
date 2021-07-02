using MappingBenchmark.Domain;

namespace MappingBenchmark.Domain
{
    public static partial class ProductVariantMapper
    {
        public static ProductVariantCodeGenDto AdaptToCodeGenDto(this ProductVariant p1)
        {
            return p1 == null ? null : new ProductVariantCodeGenDto()
            {
                Id = p1.Id,
                Color = p1.Color,
                Size = p1.Size
            };
        }
        public static ProductVariantCodeGenDto AdaptTo(this ProductVariant p2, ProductVariantCodeGenDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            ProductVariantCodeGenDto result = p3 ?? new ProductVariantCodeGenDto();
            
            result.Id = p2.Id;
            result.Color = p2.Color;
            result.Size = p2.Size;
            return result;
            
        }
    }
}