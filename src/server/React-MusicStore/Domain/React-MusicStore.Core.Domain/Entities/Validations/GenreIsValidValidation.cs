using ReactMusicStore.Core.Domain.Entities.Specifications.GenreSpecs;
using ReactMusicStore.Core.Domain.Validation;

namespace ReactMusicStore.Core.Domain.Entities.Validations
{
    public class GenreIsValidValidation : Validation<Genre>
    {
        public GenreIsValidValidation()
        {
            base.AddRule(new ValidationRule<Genre>(new GenreNameIsRequiredSpec(), ValidationMessages.NameIsRequired));
            base.AddRule(new ValidationRule<Genre>(new GenreDescriptionIsRequiredSpec(), ValidationMessages.DescriptionIsRequired));
        }
    }
}
