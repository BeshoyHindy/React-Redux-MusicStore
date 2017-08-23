using ReactMusicStore.Core.Data.Repository.EntityFramework.Common;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Interfaces.Repository;

namespace ReactMusicStore.Core.Data.Repository.EntityFramework
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
    }
}
