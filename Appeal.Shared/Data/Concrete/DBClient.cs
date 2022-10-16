using Appeal.Shared.Entities.Abstract;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Shared.Data.Concrete
{
    public class DBClient
    {
        readonly SQLConnection _sqlConn;

        public DBClient(SQLConnection sqlConn)
        {
            _sqlConn = sqlConn;
        }

        public async Task<IEnumerable<T>> QueryAll<T>(string sql)
        {
            SqlConnection connection = new SqlConnection(_sqlConn.ConnectionString);
            await connection.OpenAsync();
            var result = await connection.QueryAsync<T>(sql);
            await connection.CloseAsync();
            return result;
        }

        public async Task<IEnumerable<T>> QueryAll<T>(string sql, object parametr)
        {
            SqlConnection connection = new SqlConnection(_sqlConn.ConnectionString);
            await connection.OpenAsync();
            var result = await connection.QueryAsync<T>(sql, parametr);
            await connection.CloseAsync();
            return result;
        }

        public async Task<T> Query<T>(string sql,object parametr)
        {
            SqlConnection connection = new SqlConnection(_sqlConn.ConnectionString);
            await connection.OpenAsync();
            var result = await connection.QuerySingleOrDefaultAsync<T>(sql, parametr);
            await connection.CloseAsync();
            return result;
        }

        public async Task<int> QuerySingle<T>(string procedure, object parameter, CommandType commandType = CommandType.StoredProcedure)
        {
            SqlConnection connection = new SqlConnection(_sqlConn.ConnectionString);
            await connection.OpenAsync();
            var result = await connection.QuerySingleOrDefaultAsync<int>(procedure, parameter, commandType: commandType);
            await connection.CloseAsync();
            return result;
        }
    }
}
