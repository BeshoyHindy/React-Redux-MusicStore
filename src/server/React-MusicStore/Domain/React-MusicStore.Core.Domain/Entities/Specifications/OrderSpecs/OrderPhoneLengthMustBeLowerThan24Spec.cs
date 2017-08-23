using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderPhoneLengthMustBeLowerThan24Spec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.Phone.Length <= 24;
        }
    }
}
