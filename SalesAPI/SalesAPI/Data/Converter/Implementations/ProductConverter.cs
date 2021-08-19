using SalesAPI.Data.Converter.Contract;
using SalesAPI.Data.DTO;
using SalesAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace SalesAPI.Data.Converter.Implementations
{
    public class ProductConverter : IParser<ProductDTO, Product>, IParser<Product, ProductDTO>
    {
        public Product Parse(ProductDTO origin)
        {
            if (origin == null) return null;
            return new Product
            {
                Id = origin.Id,
                Name = origin.Description,
                CategoryId = origin.CategoryId,
                Price = origin.Price,
                Purchase = null
            };
        }

        public ProductDTO Parse(Product origin)
        {
            if (origin == null) return null;
            return new ProductDTO
            {
                Id = origin.Id,
                Description = origin.Name,
                Price = origin.Price,
                CategoryId = origin.CategoryId
            };
        }

        public List<Product> Parse(List<ProductDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<ProductDTO> Parse(List<Product> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
 }
