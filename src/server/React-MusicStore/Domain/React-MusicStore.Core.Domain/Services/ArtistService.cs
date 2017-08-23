using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Interfaces.Repository;
using ReactMusicStore.Core.Domain.Interfaces.Repository.ReadOnly;
using ReactMusicStore.Core.Domain.Interfaces.Service;
using ReactMusicStore.Core.Domain.Services.Common;

namespace ReactMusicStore.Core.Domain.Services
{
    public class ArtistService : Service<Artist>, IArtistService
    {
        public ArtistService(IArtistRepository repository, IArtistReadOnlyRepository readOnlyRepository) 
            : base(repository, readOnlyRepository)
        {
        }
    }
}
