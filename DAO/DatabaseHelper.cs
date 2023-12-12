using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DAO
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Data Source=TRUNG-LAPTOP\\ELIO;Initial Catalog=MiniMart;Integrated Security=True";

        public static DataTable ExecuteQuery(string query, SqlParameter[]? parameters = null)
        {
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            DataTable dataTable = new();
            try
            {
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Error executing query: " + ex.Message);
            }
            return dataTable;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[]? parameters = null)
        {
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            int rowsAffected = 0;
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Error executing non-query command: " + ex.Message);
            }
            return rowsAffected;
        }
    }
}
