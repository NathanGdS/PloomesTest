using SalesAPI.Data.Converter.Contract;
using SalesAPI.Data.DTO;
using SalesAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace SalesAPI.Data.Converter.Implementations
{
    public class CategoryConverter : IParser<CategoryDTO, Category>, IParser<Category, CategoryDTO>
    {
        public Category Parse(CategoryDTO origin)
        {
            if (origin == null) return null;
            return new Category
            {
                Id = origin.Id,
                Description = origin.Description,
                Enabled = true
            };
        }

        public CategoryDTO Parse(Category origin)
        {
            if (origin == null) return null;
            return new CategoryDTO
            {
                Id = origin.Id,
                Description = origin.Description
            };
        }

        public List<Category> Parse(List<CategoryDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<CategoryDTO> Parse(List<Category> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
