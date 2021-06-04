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
            Connection connection = new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADOLinq;Integrated Security=True;");

            Command command = new Command("SELECT Name FROM Category;", false);

            DataTable dataTable = connection.GetDataTable(command);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.WriteLine($"{dataRow["Name"]}");
            }


        }
    }
}
