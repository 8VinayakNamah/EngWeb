using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using log4net;
using System.Reflection;

namespace Database
{
    public enum QueryType
    {
        Text,
        StoreProc
    }

    public class SqlDatabase
    {
        static ILog log;
        private static string _connectionKey;

        static SqlDatabase()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        /// <summary>
        /// 
        /// </summary>
        public static string ConnectionKey
        {
            get { return _connectionKey; }
            set { _connectionKey = value; }
        }

        //string connectionString;
        /// <summary>
        /// returns connection object based on named connection parameter in the config
        /// </summary>
        /// <param name="configName"></param>
        /// <returns>SqlConnection</returns>
        private static SqlConnection GetConnection(string configName)
        {
            var connSection = (ConnectionStringsSection)ConfigurationManager.GetSection("connectionStrings");
            string connectionstring = connSection.ConnectionStrings[configName].ConnectionString;
            return new SqlConnection(connectionstring);
        }
        /// <summary>
        /// Return default connection based on connection string under connection string section
        /// </summary>
        /// <returns>SqlConnection</returns>
        private static SqlConnection GetConnection()        {
            
            string connectionstring = ConfigurationManager.ConnectionStrings[_connectionKey].ConnectionString; 
            return new SqlConnection(connectionstring);
        }

        //public static void Init()
        //{
        //    //var con = GetConnection("MSSql");

        //    var p = new SqlParameter("@id", SqlDbType.Int)
        //    {
        //        Direction = ParameterDirection.Input,
        //        Value = 1
        //    };
        //    ICollection<SqlParameter> param = new List<SqlParameter>();
        //    param.Add(p);          

        //    var result = ExecuteScaler("dbo.TestQuery", param, QueryType.StoreProc);
        //}


        /// <summary>
        /// Execute query/store proc and return the count of number of records impacted
        /// </summary>
        /// <param name="query">store proc or  query </param>
        /// <param name="qType">query is Store proc or text, default is store proc </param>
        /// <returns>Int </returns>
        public static int ExecuteNonQuery(string query,QueryType qType=QueryType.StoreProc)
        {
            CommandType cType;

            if (qType == QueryType.StoreProc)
                cType = CommandType.StoredProcedure;
            else
                cType = CommandType.Text;

            SqlCommand command;
            using (var connection = GetConnection())
            {
                command = new SqlCommand(query, connection)
                {
                    CommandType = cType
                };
                connection.Open();
                var result=  command.ExecuteNonQuery();
                connection.Close();
                return result;                
            }
        }

        /// <summary>
        /// Execute query/store proc and return the count of number of records impacted
        /// </summary>
        /// <param name="query">store proc or query</param>
        /// <param name="sqlparams"> iCollection of sql paramaters </param>
        /// <param name="qType">query is Store proc or text, default is store proc </param>
        /// <returns>Int</returns>
        public static int ExecuteNonQuery(string query,ICollection<SqlParameter> sqlparams, QueryType qType = QueryType.StoreProc)
        {
            SqlCommand command;

            CommandType cType;

            if (qType == QueryType.StoreProc)
                cType = CommandType.StoredProcedure;
            else
                cType = CommandType.Text;

            using (var connection = GetConnection())
            {
                command = new SqlCommand(query, connection)
                {
                    CommandType = cType

                };
                foreach(SqlParameter sparam in sqlparams)
                {
                    command.Parameters.Add(sparam);
                }

                connection.Open();
                var result =command.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }


        /// <summary>
        ///Execute query/store proc and return the first value from recordset
        /// </summary>
        /// <param name="query">store proc or query</param>
        /// <param name="qType">query is Store proc or text, default is store proc </param>
        /// <returns>object </returns>
        public static object ExecuteScaler(string query, QueryType qType = QueryType.StoreProc)
        {
            SqlCommand command;

            CommandType cType;

            if (qType == QueryType.StoreProc)
                cType = CommandType.StoredProcedure;
            else
                cType = CommandType.Text;

            using (var connection = GetConnection())
            {
                command = new SqlCommand(query, connection)
                {
                    CommandType = cType
                };
                connection.Open();
                var result= command.ExecuteScalar();
                connection.Close();
                return result;
            }
        }

        /// <summary>
        /// Execute query/store proc and return the first value from recordset
        /// </summary>
        /// <param name="query">store proc or query</param>
        /// <param name="sqlparams"> iCollection of sql paramaters </param>
        /// <param name="qType">query is Store proc or text, default is store proc </param>
        /// <returns>Object</returns>
        public static object ExecuteScaler(string query, ICollection<SqlParameter> sqlparams, QueryType qType = QueryType.StoreProc)
        {
            SqlCommand command;

            CommandType cType;

            if (qType == QueryType.StoreProc)
                cType = CommandType.StoredProcedure;
            else
                cType = CommandType.Text;

            using (var connection = GetConnection())
            {
                command = new SqlCommand(query, connection)
                {
                    CommandType = cType
                };
                foreach (SqlParameter sparam in sqlparams)
                {
                    command.Parameters.Add(sparam);
                }
                connection.Open();
                var result =  command.ExecuteScalar();
                connection.Close();
                return result;
            }
        }


        /// <summary>
        /// Execute query/store proc and return resultset as dataset
        /// </summary>
        /// <param name="query">store proc or query</param>
        /// <param name="qType">query is Store proc or text, default is store proc </param>
        /// <returns>Dataset</returns>
        public static DataSet ExecuteDataset(string query, QueryType qType = QueryType.StoreProc)
        {
            var ds = new DataSet();
            CommandType cType;

            if (qType == QueryType.StoreProc)
                cType = CommandType.StoredProcedure;
            else
                cType = CommandType.Text;

            using (var conn = GetConnection())
            {
                var command = new SqlCommand(query, conn)
                {
                    CommandType = cType
                };

                var SqlAdapter = new SqlDataAdapter(command);
                SqlAdapter.Fill(ds);
                return ds;
            }
        }


        /// <summary>
        /// Execute query/store proc and return resultset as dataset
        /// </summary>
        /// <param name="query">store proc or query</param>
        /// <param name="sqlparams"> iCollection of sql paramaters </param>
        /// <param name="qType">query is Store proc or text, default is store proc </param>
        /// <returns>Dataset</returns>
        public static DataSet ExecuteDataset(string query, ICollection<SqlParameter> sqlparams , QueryType qType = QueryType.StoreProc)
        {
            var ds = new DataSet();
            CommandType cType;

            if (qType == QueryType.StoreProc)
                cType = CommandType.StoredProcedure;
            else
                cType = CommandType.Text;

            using (var conn = GetConnection())
            {
                var command = new SqlCommand(query, conn)
                {
                    CommandType = cType
                };
                foreach (SqlParameter sparam in sqlparams)
                {
                    command.Parameters.Add(sparam);
                }
                var SqlAdapter = new SqlDataAdapter(command);
                SqlAdapter.Fill(ds);
                return ds;
            }
        }

    }
    
}
