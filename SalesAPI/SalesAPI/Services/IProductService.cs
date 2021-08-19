using SalesAPI.Data.DTO;
using System.Collections.Generic;

namespace SalesAPI.Services
{
    public interface IProductService
    {
        ProductDTO Create(ProductDTO product);
        ProductDTO FindByID(long id);
        List<ProductDTO> FindAll();
        ProductDTO Update(ProductDTO product);
        void Delete(long id);
    }
}
