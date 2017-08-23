using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ReactMusicStore.Core.Data.Context.Config
{
    public class MusicStoreConnection : DbConnection
    {
        private readonly SqlConnection _connection;
        public MusicStoreConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return _connection.BeginTransaction(isolationLevel);
        }

        public override void Close()
        {
            _connection.Close();
        }

        public override void ChangeDatabase(string databaseName)
        {
            _connection.ChangeDatabase(databaseName);
        }

        public override void Open()
        {
            _connection.Open();
        }

        public override string ConnectionString
        {
            get => _connection.ConnectionString;
            set => _connection.ConnectionString = value;
        }

        public override string Database => _connection.Database;

        public override ConnectionState State => _connection.State;

        public override string DataSource => _connection.DataSource;

        public override string ServerVersion => _connection.ServerVersion;

        protected override DbCommand CreateDbCommand()
        {
            return _connection.CreateCommand();
        }
    }
}