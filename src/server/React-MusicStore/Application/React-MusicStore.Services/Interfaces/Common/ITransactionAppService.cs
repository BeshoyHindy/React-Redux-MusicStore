using ReactMusicStore.Core.Data.Context.Interfaces;

namespace ReactMusicStore.Services.Interfaces.Common
{
    public interface ITransactionAppService<TContext>
        where TContext : IDbContext, new()
    {
        void BeginTransaction();
        void Commit();
    }
}
