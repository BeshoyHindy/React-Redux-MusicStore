﻿using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Interfaces.Repository.Common;

namespace ReactMusicStore.Core.Domain.Interfaces.Repository.ReadOnly
{
    public interface ICartReadOnlyRepository : IReadOnlyRepository<Cart>
    {
         
    }
}