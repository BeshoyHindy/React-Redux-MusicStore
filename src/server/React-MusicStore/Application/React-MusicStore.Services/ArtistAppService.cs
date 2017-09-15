using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ReactMusicStore.Core.Data.Context;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Interfaces.Service;
using ReactMusicStore.Core.Domain.Validation;
using ReactMusicStore.Services.Interfaces;

namespace ReactMusicStore.Services
{
    public class ArtistAppService : AppService<DbMusicStoreContext>, IArtistAppService
    {
        private readonly IArtistService _service;

        public ArtistAppService(IArtistService artistService)
        {
            _service = artistService;
        }

        public ValidationResult Create(Artist artist)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(artist));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Artist artist)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(artist));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Artist artist)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(artist));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Artist Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Artist> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Artist> Find(Expression<Func<Artist, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}