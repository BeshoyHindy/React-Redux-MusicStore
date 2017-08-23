using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.CartSpecs
{
    public class CartCountShouldBeGreaterThanZeroSpec : ISpecification<Cart>
    {
        public bool IsSatisfiedBy(Cart cart)
        {
            return cart.Count > 0;
        }
    }
}
