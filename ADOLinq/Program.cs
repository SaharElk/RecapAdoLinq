using System;
using System.Data;
using System.Data.SqlClient;
using Tools.Connections.Database;

namespace ADOLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test Connection
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADOLinq;Integrated Security=True;";

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT Name FROM Category;";

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            Console.WriteLine($"{dataRow["Name"]}");
                        }
                    }
                }
            }

        }
    }
}
