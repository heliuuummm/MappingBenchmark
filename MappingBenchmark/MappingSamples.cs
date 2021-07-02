using AutoMapper;
using MappingBenchmark.Domain;
using MappingBenchmark.Dtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MappingBenchmark
{
    public class MappingSamples
    {
        private static readonly IMapper AutoMapper = new Mapper(new MapperConfiguration(ex => ex.AddProfile(new AutomapperProfile())));

        private static readonly TypeAdapterConfig TypeAdapterConfig = GetTypeAdapterConfig();

        private static readonly MapsterMapper.IMapper MapsterMapper = new MapsterMapper.Mapper(TypeAdapterConfig);

        static MappingSamples()
        {
            ExpressMapper.Mapper.Register<Product, ProductDto>();
        }

        public static ProductDto ExpressMapperSample()
        {
            return ExpressMapper.Mapper.Map<Product, ProductDto>(GenerateProduct);
        }

        public static ProductDto AutoMapperSample()
        {
            return AutoMapper.Map<ProductDto>(GenerateProduct);
        }

        public static ProductDto MapsterAdapterWithoutConfigSample()
        {
            return GenerateProduct.Adapt<ProductDto>();
        }

        public static ProductDto MapsterAdapterWithConfigSample()
        {
            return GenerateProduct.Adapt<ProductDto>(TypeAdapterConfig);
        }

        public static ProductDto MapsterAdaptToTypeSample()
        {
            return MapsterMapper.From(GenerateProduct).AdaptToType<ProductDto>();
        }

        public static ProductCodeGenDto MapsterCodeGenSample()
        {
            return GenerateProduct.AdaptToCodeGenDto();
        }

        public static ProductDto ManualMapSample()
        {
            var product = GenerateProduct;
            var dto = new ProductDto
            {
                Id = product.Id,
                Description = product.Description,
                Weight = product.Weight,
                ProductName = product.ProductName,
                DefaultOption = new ProductVariantDto
                {
                    Id = product.DefaultOption.Id,
                    Color = product.DefaultOption.Color,
                    Size = product.DefaultOption.Size
                }
            };

            var options = new List<ProductVariantDto>();

            for (var i = 0; i < product.Options.Count; i++)
            {
                options.Add(new ProductVariantDto
                {
                    Id = product.Options[i].Id,
                    Color = product.Options[i].Color,
                    Size = product.Options[i].Size
                });
            }

            dto.Options = options;

            return dto;
        }

        public static TypeAdapterConfig GetTypeAdapterConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<Product, ProductDto>();
            return config;
        }


        public static readonly Product GenerateProduct = new()
        {
            Id = Guid.Parse("1fe0b443-daf9-4a86-9123-e5ed9fd97d82"),
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eu velit vehicula, consectetur sapien non.",
            Weight = 50m,
            ProductName = "Generated Product",
            DefaultOption = new ProductVariant
            {
                Id = Guid.Parse("1fe0b443-daf9-4a86-9123-e5ed9fd97d82"),
                Color = "Red",
                Size = "Small"
            },
            Options = new List<ProductVariant>
            {
                new()
                {
                    Id = Guid.Parse("1fe0b443-daf9-4a86-9123-e5ed9fd97d82"),
                    Color = "Red",
                    Size = "Small"
                },
                new()
                {
                    Id = Guid.Parse("1fe0b443-daf9-4a86-9123-e5ed9fd97d82"),
                    Color = "Blue",
                    Size = "Medium"
                },
                new()
                {
                    Id = Guid.Parse("1fe0b443-daf9-4a86-9123-e5ed9fd97d82"),
                    Color = "Green",
                    Size = "Large"
                }
            }
        };
    }

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductVariant, ProductVariantDto>();
            CreateMap<Product, ProductDto>();
        }
    }

}
