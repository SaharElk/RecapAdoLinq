using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOLinq.Client.Data
{
    public class Contact
    {
        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int IdCategory { get; set; }

        public Contact(string lastName, string firstName, string email, int idCategory)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            IdCategory = idCategory;
        }

        public Contact(int id, string lastName, string firstName, string email, int idCategory)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            IdCategory = idCategory;
        }
    }
}
