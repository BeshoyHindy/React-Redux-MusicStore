using System;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;

namespace ReactMusicStore.Core.Data.Repository.Dapper.Common
{
    public class Repository : IDisposable
    {
        public IDbConnection MusicStoreConnection => new SqlCeConnection(ConfigurationManager.ConnectionStrings["MusicStoreEntities"].ConnectionString);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
