using System;
using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderStateIsRequiredSpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return !String.IsNullOrEmpty(order.State) && !String.IsNullOrWhiteSpace(order.State);
        }
    }
}
