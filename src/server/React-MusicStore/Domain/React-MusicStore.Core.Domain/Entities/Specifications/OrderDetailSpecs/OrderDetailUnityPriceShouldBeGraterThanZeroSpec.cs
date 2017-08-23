using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderDetailSpecs
{
    public class OrderDetailUnityPriceShouldBeGraterThanZeroSpec : ISpecification<OrderDetail>
    {
        public bool IsSatisfiedBy(OrderDetail orderDetail)
        {
            return orderDetail.UnitPrice > 0;
        }
    }
}
