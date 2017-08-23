using ReactMusicStore.Core.Domain.Entities.Specifications.CartSpecs;
using ReactMusicStore.Core.Domain.Validation;

namespace ReactMusicStore.Core.Domain.Entities.Validations
{
    public class CartIsValidValidation : Validation<Cart>
    {
        public CartIsValidValidation()
        {
            base.AddRule(new ValidationRule<Cart>(new CartCountShouldBeGreaterThanZeroSpec(), ValidationMessages.NameIsRequired));
        }
    }
}
