using SalesAPI.Data.Converter.Implementations;
using SalesAPI.Data.DTO;
using SalesAPI.Model;
using SalesAPI.Repository.Generic;
using System.Collections.Generic;

namespace SalesAPI.Services.Implementations
{
    public class CategoryServicesImplementation : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly CategoryConverter _converter;

        public CategoryServicesImplementation(IRepository<Category> repository)
        {
            _repository = repository;
            _converter = new CategoryConverter();
        }

        public List<CategoryDTO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public CategoryDTO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public CategoryDTO Create(CategoryDTO category)
        {
            var categoryEntity = _converter.Parse(category);
            categoryEntity = _repository.Create(categoryEntity);
            return _converter.Parse(categoryEntity);
        }

        public CategoryDTO Update(CategoryDTO category)
        {
            var categoryEntity = _converter.Parse(category);
            categoryEntity = _repository.Update(categoryEntity);
            return _converter.Parse(categoryEntity);

        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
