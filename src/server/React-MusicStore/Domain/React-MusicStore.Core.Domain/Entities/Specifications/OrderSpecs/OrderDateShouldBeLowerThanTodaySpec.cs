using System;
using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderDateShouldBeLowerThanTodaySpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.OrderDate.Date <= DateTime.Today;
        }
    }
}
