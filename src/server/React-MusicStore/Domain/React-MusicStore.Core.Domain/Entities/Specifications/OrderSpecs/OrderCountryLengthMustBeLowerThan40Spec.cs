using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderCountryLengthMustBeLowerThan40Spec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.Country.Length <= 40;
        }
    }
}
