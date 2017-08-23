using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderDetailSpecs
{
    public class OrderDetailQuantityShouldBeGraterThanZeroSpec : ISpecification<OrderDetail>
    {
        public bool IsSatisfiedBy(OrderDetail orderDetail)
        {
            return orderDetail.Quantity > 0;
        }
    }
}
