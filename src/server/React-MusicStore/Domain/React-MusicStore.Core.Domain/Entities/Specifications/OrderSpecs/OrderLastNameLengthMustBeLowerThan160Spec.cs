using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderLastNameLengthMustBeLowerThan160Spec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.LastName.Length <= 160;
        }
    }
}
