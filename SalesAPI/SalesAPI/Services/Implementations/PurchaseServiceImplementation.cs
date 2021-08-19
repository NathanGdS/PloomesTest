using SalesAPI.Data.Converter.Implementations;
using SalesAPI.Data.DTO;
using SalesAPI.Model;
using SalesAPI.Repository.Generic;
using System.Collections.Generic;

namespace SalesAPI.Services.Implementations
{
    public class PurchaseServicesImplementation : IPurchaseService
    {
        private readonly IRepository<Purchase> _repository;
        private readonly PurchaseConverter _converter;

        public PurchaseServicesImplementation(IRepository<Purchase> repository)
        {
            _repository = repository;
            _converter = new PurchaseConverter();
        }

        public List<PurchaseDTO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PurchaseDTO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public PurchaseDTO Create(PurchaseDTO purchase)
        {
            var purchaseEntity = _converter.Parse(purchase);
            purchaseEntity = _repository.Create(purchaseEntity);
            return _converter.Parse(purchaseEntity);
        }

        public PurchaseDTO Update(PurchaseDTO purchase)
        {
            var purchaseEntity = _converter.Parse(purchase);
            purchaseEntity = _repository.Update(purchaseEntity);
            return _converter.Parse(purchaseEntity);

        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
