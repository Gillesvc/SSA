using Oef2.Models;
using Microsoft.Extensions.Options;
using System;
using System.Data.Common;

namespace Oef2.DataAccess {
    public class Database {
        private IOptions<DatabaseSettings> _settings;

        public Database(IOptions<DatabaseSettings> settings) {
            _settings = settings;
        }

        private DbConnection GetConnection() {
            DbConnection conn = DbProviderFactories.GetFactory(_settings.Value.ProviderName).CreateConnection();
            conn.ConnectionString = _settings.Value.ConnectionString;
            conn.Open();
            return conn;
        }

        //returns an open transaction using the given connection string name
        public DbTransaction BeginTransaction() {
            DbConnection conn = GetConnection();
            DbTransaction trans = conn.BeginTransaction();
            return trans;
        }

        //BuildCommand x2
        private DbCommand BuildCommand(string sql, params DbParameter[] parameters) {
            DbConnection conn = GetConnection();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return cmd;
        }

        private DbCommand BuildCommand(DbTransaction trans, string sql, params DbParameter[] parameters) {
            DbConnection conn = trans.Connection;
            DbCommand cmd = conn.CreateCommand();
            cmd.Transaction = trans; //!! transaction instellen op command !!
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return cmd;
        }

        //BuildParameter
        public DbParameter BuildParameter(string paramName, object paramValue) {
            DbParameter param = DbProviderFactories.GetFactory(_settings.Value.ProviderName).CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            return param;
        }

        //GetData() x2
        public DbDataReader GetData(string sql, params DbParameter[] parameters) {
            DbCommand cmd = null;
            DbDataReader reader = null;

            try {
                cmd = BuildCommand(sql, parameters);
                reader = cmd.ExecuteReader();
                return reader;
            } catch (Exception) {
                if (cmd != null)
                    ReleaseConnection(cmd.Connection);
                if (reader != null)
                    reader.Close();
                throw;
            }
        }

        public DbDataReader GetData(DbTransaction trans, string sql, params DbParameter[] parameters) {
            DbCommand cmd = null;
            DbDataReader reader = null;

            try {
                cmd = BuildCommand(trans, sql, parameters);
                reader = cmd.ExecuteReader();
                return reader;
            } catch (Exception) {
                if (cmd != null)
                    ReleaseConnection(cmd.Connection);
                if (reader != null)
                    reader.Close();
                throw;
            }
        }


        //ModifyData() x2
        public int ModifyData(string connStrName, string sql, params DbParameter[] parameters) {
            DbCommand cmd = null;

            try {
                cmd = BuildCommand(sql, parameters);
                int numRows = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return numRows;
            } catch (Exception) {
                if (cmd != null)
                    ReleaseConnection(cmd.Connection);
                throw;
            }
        }

        public int ModifyData(DbTransaction trans, string sql, params DbParameter[] parameters) {
            DbCommand cmd = null;

            try {
                cmd = BuildCommand(trans, sql, parameters);
                int numRows = cmd.ExecuteNonQuery();
                return numRows;
            } catch (Exception) {
                if (cmd != null) {
                    cmd.Parameters.Clear();
                    ReleaseConnection(cmd.Connection);
                }
                throw;
            }
        }


        //InsertData() x2
        public int InsertData(string sql, params DbParameter[] parameters) {
            DbCommand cmd = null;

            try {
                //execute given command
                cmd = BuildCommand(sql, parameters);
                cmd.ExecuteNonQuery();

                //execute new command to get last ID
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT @@IDENTITY";
                int id = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                return id;
            } catch (Exception) {
                if (cmd != null)
                    ReleaseConnection(cmd.Connection);
                throw;
            }
        }

        public int InsertData(DbTransaction trans, string sql, params DbParameter[] parameters) {
            DbCommand cmd = null;

            try {
                //execute given command
                cmd = BuildCommand(trans, sql, parameters);
                cmd.ExecuteNonQuery();

                //execute new command to get last ID
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT @@IDENTITY";
                int id = cmd.ExecuteNonQuery();
                return id;
            } catch (Exception) {
                if (cmd != null)
                    ReleaseConnection(cmd.Connection);
                throw;
            }
        }


        public void ReleaseConnection(DbConnection connection) {
            if (connection != null) {
                connection.Close();
                connection = null;
            }
        }
    }
}
