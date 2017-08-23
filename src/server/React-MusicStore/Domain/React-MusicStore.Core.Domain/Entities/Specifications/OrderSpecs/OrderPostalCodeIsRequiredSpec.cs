using System;
using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderPostalCodeIsRequiredSpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return !String.IsNullOrEmpty(order.PostalCode) && !String.IsNullOrWhiteSpace(order.PostalCode);
        }
    }
}
