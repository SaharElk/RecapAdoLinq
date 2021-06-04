using ADOLinq.Models;
using ADOLinq.Services;
using System;
using System.Collections.Generic;
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

            //Category cat = new Category() { Name = "Sans Emploi" };

            //categoriesService.Insert(cat);

            //IEnumerable<Category> categories = categoriesService.Get();

            //foreach (Category category in categories)
            //{
            //    Console.WriteLine($"{category.Id} {category.Name}");
            //}

            //Category category = categoriesService.Get(3);
            //if (category != null)
            //{
            //    Console.WriteLine($"{category.Id} {category.Name}");

            //}

            ContactsService contactsService = new ContactsService(connection);

            //Contact myContact = new Contact() { LastName = "Nom de Toto", FirstName = "Toto", Email = "tot@test.com", IdCategory = 2 };

            //contactsService.Insert(myContact);

            //myContact.FirstName = "Mickey";
            //contactsService.Update(2, myContact);

            //contactsService.Delete(3);

            //IEnumerable<Contact> contacts = contactsService.Get();

            //foreach (Contact contact in contacts)
            //{
            //    Console.WriteLine($"{contact.Id} {contact.LastName} {contact.FirstName} {contact.Email} {contact.IdCategory}");
            //}

        }
    }
}
