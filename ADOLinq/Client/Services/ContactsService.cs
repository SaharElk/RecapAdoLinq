using ADOLinq.Client.Data;
using ADOLinq.Client.Mappers;
using ADOLinq.Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G = ADOLinq.Services;

namespace ADOLinq.Client.Services
{
    public class ContactsService : IContactsRepository
    {
        private readonly G.ContactsService _contactsService;

        public ContactsService(G.ContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        public IEnumerable<Contact> Get()
        {
            return _contactsService.Get().Select(c => c.ToClient());
        }

        public IEnumerable<Contact> GetByCategory(int id)
        {
            return _contactsService.GetByCategory(id).Select(c => c.ToClient());
        }

        public Contact Get(int id)
        {
            return _contactsService.Get(id).ToClient();
        }

        public bool Insert(Contact contact)
        {
            return _contactsService.Insert(contact.ToGlobal());
        }

        public bool Update(int id, Contact contact)
        {
            return _contactsService.Update(id, contact.ToGlobal());
        }

        public bool Delete(int id)
        {
            return _contactsService.Delete(id);
        }
    }
}
