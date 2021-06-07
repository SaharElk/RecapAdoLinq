using ADOLinq.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G = ADOLinq.Models;

namespace ADOLinq.Client.Mappers
{
    public static class Mappers
    {
        public static Contact ToClient(this G.Contact contact)
        {
            return new Contact(contact.Id, contact.LastName, contact.FirstName, contact.Email, contact.IdCategory);
        }

        public static G.Contact ToGlobal(this Contact contact)
        {
            return new G.Contact() 
            { 
                Id = contact.Id, 
                LastName = contact.LastName, 
                FirstName = contact.FirstName, 
                Email = contact.Email, 
                IdCategory = contact.IdCategory
            };
        }

        public static Category ToClient(this G.Category category)
        {
            return new Category(category.Id, category.Name);
        }

        public static G.Category ToGlobal(this Category category)
        {
            return new G.Category()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}
