using System;
using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderFirstNameIsRequiredSpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return !String.IsNullOrEmpty(order.FirstName) && !String.IsNullOrWhiteSpace(order.FirstName);
        }
    }
}
