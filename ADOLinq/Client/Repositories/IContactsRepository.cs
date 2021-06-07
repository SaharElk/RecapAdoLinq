using ADOLinq.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOLinq.Client.Repositories
{
    public interface IContactsRepository
    {
        public IEnumerable<Contact> Get();

        public IEnumerable<Contact> GetByCategory(int id);

        public Contact Get(int id);

        public bool Insert(Contact contact);

        public bool Update(int id, Contact contact);

        public bool Delete(int id);
    }
}
