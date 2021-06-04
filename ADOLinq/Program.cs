using ADOLinq.Services;
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

            CategoriesService categoriesService = new CategoriesService(connection);
        }
    }
}
