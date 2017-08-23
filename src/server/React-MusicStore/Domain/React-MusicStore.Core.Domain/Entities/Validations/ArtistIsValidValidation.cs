using ReactMusicStore.Core.Domain.Entities.Specifications.ArtistSpecs;
using ReactMusicStore.Core.Domain.Validation;

namespace ReactMusicStore.Core.Domain.Entities.Validations
{
    public class ArtistIsValidValidation : Validation<Artist>
    {
        public ArtistIsValidValidation()
        {
            base.AddRule(new ValidationRule<Artist>(new ArtistNameIsRequiredSpec(), ValidationMessages.NameIsRequired));
        }
    }
}
