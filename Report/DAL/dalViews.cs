using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Report.Domain;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace Report.DAL
{
    public class dalViews
    {
        // Use Dapper for fetching data from database

        // Define Connection String

        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Connection Details

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        // Fetching Data from database
        public static List<clsViews> FetchList()
        {
            string sql = "SELECT * FROM YoutubeViews";

            using (var con = GetConnection())
            {
                return con.Query<clsViews>(sql).ToList();
            }

        }

    }
}