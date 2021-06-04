using ADOLinq.Models;
using ADOLinq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;

namespace ADOLinq.Services
{
    public class ContactsService
    {
        private readonly Connection _connection;

        public ContactsService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> Get()
        {
            Command command = new Command("SELECT Id, LastName, FirstName, Email, IdCategory FROM Contact;", false);

            return _connection.ExecuteReader(command, (record) => record.ToContact());
        }

        public IEnumerable<Contact> GetByCategory(int id)
        {
            Command command = new Command("SELECT Id, LastName, FirstName, Email, IdCategory FROM Contact WHERE IdCategory =@Id;", false);
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, (record) => record.ToContact());
        }

        public Contact Get(int id)
        {
            Command command = new Command("SELECT Id, LastName, FirstName, Email, IdCategory FROM Contact WHERE Id =@Id;", false);
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, (record) => record.ToContact()).FirstOrDefault();
        }

        public bool Insert(Contact contact)
        {
            Command command = new Command("INSERT INTO Contact(LastName, FirstName, Email, IdCategory) VALUES(@LastName, @FirstName, @Email, @IdCategory);", false);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("IdCategory", contact.IdCategory);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Update(int id, Contact contact)
        {
            Command command = new Command("UPDATE Contact SET LastName = @LastName, FirstName = @FirstName, Email = @Email, IdCategory = @IdCategory WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.LastName);
            command.AddParameter("IdCategory", contact.IdCategory);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            Command command = new Command("DELETE Contact WHERE Id = @Id;", false);
            command.AddParameter("Id", id);

            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
