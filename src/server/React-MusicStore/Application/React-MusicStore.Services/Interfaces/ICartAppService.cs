using System.Collections.Generic;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Validation;
using ReactMusicStore.Services.Interfaces.Common;

namespace ReactMusicStore.Services.Interfaces
{
    public interface ICartAppService : IAppService<Cart>
    {
        ValidationResult Remove(IEnumerable<Cart> carts);
        ValidationResult Update(IEnumerable<Cart> carts);
    }
}
