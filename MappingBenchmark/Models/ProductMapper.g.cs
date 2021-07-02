using System.Collections.Generic;
using MappingBenchmark.Domain;

namespace MappingBenchmark.Domain
{
    public static partial class ProductMapper
    {
        public static ProductCodeGenDto AdaptToCodeGenDto(this Product p1)
        {
            return p1 == null ? null : new ProductCodeGenDto()
            {
                Id = p1.Id,
                ProductName = p1.ProductName,
                Weight = p1.Weight,
                Description = p1.Description,
                Options = funcMain1(p1.Options),
                DefaultOption = p1.DefaultOption == null ? null : new ProductVariantCodeGenDto()
                {
                    Id = p1.DefaultOption.Id,
                    Color = p1.DefaultOption.Color,
                    Size = p1.DefaultOption.Size
                }
            };
        }
        public static ProductCodeGenDto AdaptTo(this Product p3, ProductCodeGenDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            ProductCodeGenDto result = p4 ?? new ProductCodeGenDto();
            
            result.Id = p3.Id;
            result.ProductName = p3.ProductName;
            result.Weight = p3.Weight;
            result.Description = p3.Description;
            result.Options = funcMain2(p3.Options, result.Options);
            result.DefaultOption = funcMain3(p3.DefaultOption, result.DefaultOption);
            return result;
            
        }
        
        private static List<ProductVariantCodeGenDto> funcMain1(List<ProductVariant> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<ProductVariantCodeGenDto> result = new List<ProductVariantCodeGenDto>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                ProductVariant item = p2[i];
                result.Add(item == null ? null : new ProductVariantCodeGenDto()
                {
                    Id = item.Id,
                    Color = item.Color,
                    Size = item.Size
                });
                i++;
            }
            return result;
            
        }
        
        private static List<ProductVariantCodeGenDto> funcMain2(List<ProductVariant> p5, List<ProductVariantCodeGenDto> p6)
        {
            if (p5 == null)
            {
                return null;
            }
            List<ProductVariantCodeGenDto> result = new List<ProductVariantCodeGenDto>(p5.Count);
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                ProductVariant item = p5[i];
                result.Add(item == null ? null : new ProductVariantCodeGenDto()
                {
                    Id = item.Id,
                    Color = item.Color,
                    Size = item.Size
                });
                i++;
            }
            return result;
            
        }
        
        private static ProductVariantCodeGenDto funcMain3(ProductVariant p7, ProductVariantCodeGenDto p8)
        {
            if (p7 == null)
            {
                return null;
            }
            ProductVariantCodeGenDto result = p8 ?? new ProductVariantCodeGenDto();
            
            result.Id = p7.Id;
            result.Color = p7.Color;
            result.Size = p7.Size;
            return result;
            
        }
    }
}