using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderAddressLengthMustBeLowerThan70Spec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.Address.Length <= 70;
        }
    }
}
