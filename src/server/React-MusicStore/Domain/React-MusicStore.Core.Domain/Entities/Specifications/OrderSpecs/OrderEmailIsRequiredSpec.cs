using System;
using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderEmailIsRequiredSpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return !String.IsNullOrEmpty(order.Email) && !String.IsNullOrWhiteSpace(order.Email);
        }
    }
}
