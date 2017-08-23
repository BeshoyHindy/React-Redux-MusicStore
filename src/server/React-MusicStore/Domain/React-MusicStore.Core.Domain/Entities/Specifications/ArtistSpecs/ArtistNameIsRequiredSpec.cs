﻿using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.ArtistSpecs
{
    public class ArtistNameIsRequiredSpec : ISpecification<Artist>
    {
        public bool IsSatisfiedBy(Artist artist)
        {
            return artist.Name.Trim().Length > 0;
        }
    }
}
