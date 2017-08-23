using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderStateLengthMustBeLowerThan40Spec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.State.Length <= 40;
        }
    }
}
