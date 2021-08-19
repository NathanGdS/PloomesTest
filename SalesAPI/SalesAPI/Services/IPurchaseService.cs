using SalesAPI.Data.DTO;
using SalesAPI.Model;
using System.Collections.Generic;

namespace SalesAPI.Services
{
    public interface IPurchaseService
    {
        PurchaseDTO Create(PurchaseDTO purchase);
        PurchaseDTO FindByID(long id);
        List<PurchaseDTO> FindAll();
        PurchaseDTO Update(PurchaseDTO purchase);
        void Delete(long id);
    }
}
