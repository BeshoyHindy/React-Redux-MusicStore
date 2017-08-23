﻿using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderTotalShouldBeGreaterThanZero : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.Total > 0;
        }
    }
}
