using ADOLinq.Extensions;
using ADOLinq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;

namespace ADOLinq.Services
{
    public class CategoriesService
    {
        private readonly Connection _connection;

        public CategoriesService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Category> Get()
        {
            Command command = new Command("SELECT Id, Name FROM Category;", false);

            return _connection.ExecuteReader(command, (record) => record.ToCategory());
        }
    }
}
