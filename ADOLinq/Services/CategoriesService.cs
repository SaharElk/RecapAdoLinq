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

        public Category Get(int id)
        {
            Command command = new Command("SELECT Id, Name FROM Category WHERE Id =@Id;", false);
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, (record) => record.ToCategory()).FirstOrDefault();
        }

        public bool Insert(Category category)
        {
            Command command = new Command("INSERT INTO Category(Name) VALUES(@Name);", false);
            command.AddParameter("Name", category.Name);

            return _connection.ExecuteNonQuery(command) == 1;

            //Command command = new Command("INSERT INTO Category(Name) output inserted.Id VALUES(@Name);", false);
            //command.AddParameter("Name", category.Name);

            //category.Id = (int)_connection.ExecuteScalar(command);
            //return true;
        }
    }
}
