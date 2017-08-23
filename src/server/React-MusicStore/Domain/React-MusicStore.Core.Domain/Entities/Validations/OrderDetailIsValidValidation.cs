using ReactMusicStore.Core.Domain.Entities.Specifications.OrderDetailSpecs;
using ReactMusicStore.Core.Domain.Validation;

namespace ReactMusicStore.Core.Domain.Entities.Validations
{
    public class OrderDetailIsValidValidation : Validation<OrderDetail>
    {
        public OrderDetailIsValidValidation()
        {
            base.AddRule(new ValidationRule<OrderDetail>(new OrderDetailQuantityShouldBeGraterThanZeroSpec(), ValidationMessages.QuantityIsInvalid));
            base.AddRule(new ValidationRule<OrderDetail>(new OrderDetailUnityPriceShouldBeGraterThanZeroSpec(), ValidationMessages.UnityPriceIsInvalid));
        }
    }
}
