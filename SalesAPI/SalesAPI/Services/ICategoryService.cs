using SalesAPI.Data.DTO;
using System.Collections.Generic;

namespace SalesAPI.Services
{
    public interface ICategoryService
    {
        CategoryDTO Create(CategoryDTO category);
        CategoryDTO FindByID(long id);
        List<CategoryDTO> FindAll();
        CategoryDTO Update(CategoryDTO category);
        void Delete(long id);
    }
}
