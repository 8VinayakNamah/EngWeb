using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient

   public class PostgresDatabase
    {
       static string connectionString; 

         static PostgresDatabase()
        {
            connectionString= ConfigurationManager.ConnectionStrings["postgres"].ConnectionString;
        }
        
        /// <summary>
        /// Initialize the postgress db class . Verify if database can be reached
        /// do other process if required 
        /// </summary>
        /// <returns></returns>
        public static bool Init()
        {
            string query = "select current_timestamp";
            ExecuteScaler(query);
            return true;
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public static int ExecuteNonQuery(string query)
        {
            SqlCommand command;
            using (var connection = GetConnection())
            {
                command = new SqlCommand(query, connection) {
                    CommandType = CommandType.Text
                };
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
        public static object ExecuteScaler(string query)
        {
            SqlCommand command;
            using (var connection = GetConnection())
            {
                command = new SqlCommand(query, connection) { 
                CommandType=CommandType.Text
                };
                connection.Open();
                return command.ExecuteScalar();
                
            }
        }
        public static DataSet ExecuteDataset(string query)
        {
            var ds = new DataSet();
            using(var conn = GetConnection())
            {
                var command = new SqlCommand(query, conn)
                {
                    CommandType = System.Data.CommandType.Text
                };
                var npgsqlAdapter = new SqlDataAdapter(command);
                npgsqlAdapter.Fill(ds);
                return ds;
            }
        }


    }
