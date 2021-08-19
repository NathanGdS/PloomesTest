using SalesAPI.Data.Converter.Contract;
using SalesAPI.Data.DTO;
using SalesAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesAPI.Data.Converter.Implementations
{
    public class PurchaseConverter : IParser<PurchaseDTO, Purchase>, IParser<Purchase, PurchaseDTO>
    {
        public Purchase Parse(PurchaseDTO origin)
        {
            if (origin == null) return null;
            return new Purchase
            {
                UserId = origin.UserId,
                ProductId = origin.ProductId,
                Date = new DateTime()
            };
        }

        public PurchaseDTO Parse(Purchase origin)
        {
            if (origin == null) return null;
            return new PurchaseDTO
            {
                UserId = origin.UserId,
                ProductId = origin.ProductId
            };
        }

        public List<Purchase> Parse(List<PurchaseDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PurchaseDTO> Parse(List<Purchase> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
