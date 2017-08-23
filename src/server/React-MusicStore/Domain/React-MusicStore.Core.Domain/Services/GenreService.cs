using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Interfaces.Repository;
using ReactMusicStore.Core.Domain.Interfaces.Repository.ReadOnly;
using ReactMusicStore.Core.Domain.Interfaces.Service;
using ReactMusicStore.Core.Domain.Services.Common;

namespace ReactMusicStore.Core.Domain.Services
{
    public class GenreService : Service<Genre>, IGenreService
    {
        private readonly IGenreReadOnlyRepository _readOnlyRepository;
        public GenreService(IGenreRepository repository, IGenreReadOnlyRepository readOnlyRepository, IGenreReadOnlyRepository readOnlyRepository1) 
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
        }

        public Genre GetWithAlbums(string genreName)
        {
            return _readOnlyRepository.GetWithAlbums(genreName);
        }
    }
}
