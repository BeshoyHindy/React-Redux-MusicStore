using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Interfaces.Repository;
using ReactMusicStore.Core.Domain.Interfaces.Repository.ReadOnly;
using ReactMusicStore.Core.Domain.Interfaces.Service;
using ReactMusicStore.Core.Domain.Services.Common;

namespace ReactMusicStore.Core.Domain.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        public OrderService(IOrderRepository repository, IOrderReadOnlyRepository readOnlyRepository) 
            : base(repository, readOnlyRepository)
        {
        }
    }
}
