using SalesAPI.Data.Converter.Implementations;
using SalesAPI.Data.DTO;
using SalesAPI.Model;
using SalesAPI.Repository.Generic;
using System;
using System.Collections.Generic;

namespace SalesAPI.Services.Implementations
{
    public class ProductServicesImplementation : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly ProductConverter _converter;

        public ProductServicesImplementation(IRepository<Product> repository)
        {
            _repository = repository;
            _converter = new ProductConverter();
        }

        public List<ProductDTO> FindAll()
        {
            try
            {
                return _converter.Parse(_repository.FindAll());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ProductDTO FindByID(long id)
        {
            try
            {
                return _converter.Parse(_repository.FindByID(id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ProductDTO Create(ProductDTO product)
        {
            var productEntity = _converter.Parse(product);
            productEntity = _repository.Create(productEntity);
            return _converter.Parse(productEntity);
        }

        public ProductDTO Update(ProductDTO product)
        {
            try
            {
                var productEntity = _converter.Parse(product);
                productEntity = _repository.Update(productEntity);
                return _converter.Parse(productEntity);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
