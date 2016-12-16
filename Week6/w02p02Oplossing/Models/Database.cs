using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;

namespace w02p02Oplossing.Models
{
    public class Database
    {
        private IOptions<DatabaseSettings> _settings;

        public Database(IOptions<DatabaseSettings> settings)
        {
            _settings = settings;
        }

        private DbConnection GetConnection()
        {
            DbConnection conn = DbProviderFactories.GetFactory(_settings.Value.ProviderName).CreateConnection();
            conn.ConnectionString = _settings.Value.ConnectionString;
            conn.Open();
            return conn;
        }

        //returns an open transaction using the given connection string name
        public DbTransaction BeginTransaction()
        {
            DbConnection conn = GetConnection();
            DbTransaction trans = conn.BeginTransaction();
            return trans;
        }

        //BuildCommand x2
        private DbCommand BuildCommand(string sql, params DbParameter[] parameters)
        {
            DbConnection conn = GetConnection();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return cmd;
        }
    }
}