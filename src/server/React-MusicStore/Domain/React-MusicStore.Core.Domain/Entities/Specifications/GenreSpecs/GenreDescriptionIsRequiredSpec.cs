using System;
using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.GenreSpecs
{
    public class GenreDescriptionIsRequiredSpec : ISpecification<Genre>
    {
        public bool IsSatisfiedBy(Genre genre)
        {
            return !String.IsNullOrEmpty(genre.Description) && !String.IsNullOrWhiteSpace(genre.Description);
        }
    }
}
