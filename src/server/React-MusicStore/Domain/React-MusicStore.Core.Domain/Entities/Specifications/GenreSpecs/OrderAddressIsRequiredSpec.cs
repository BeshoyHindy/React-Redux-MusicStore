using System;
using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.GenreSpecs
{
    public class GenreNameIsRequiredSpec : ISpecification<Genre>
    {
        public bool IsSatisfiedBy(Genre genre)
        {
            return !String.IsNullOrEmpty(genre.Name) && !String.IsNullOrWhiteSpace(genre.Name);
        }
    }
}
