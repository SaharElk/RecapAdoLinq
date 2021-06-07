using Services = ADOLinq.Services;
using ADOLinq.Client.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Tools.Connections.Database;
using ADOLinq.Client.Data;

namespace ADOLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test Connection
            Connection connection = new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADOLinq;Integrated Security=True;");

            Services.CategoriesService gCategoriesService = new Services.CategoriesService(connection);
            Services.ContactsService gContactsService = new Services.ContactsService(connection);

            CategoriesService categoriesService = new CategoriesService(gCategoriesService);
            ContactsService contactsService = new ContactsService(gContactsService);

            // Liste des catégories
            IEnumerable<Category> categories = categoriesService.Get();

            foreach (Category category in categories)
            {
                Console.WriteLine($"{category.Id} {category.Name}");
            }

            // Ajout de la catégorie Autre
            Category category1 = new Category("Autre");
            categoriesService.Insert(category1);

            // Récupération de la catégorie avec l'id = 2
            Category category2 = categoriesService.Get(2);
            if (category2 != null)
            {
                Console.WriteLine($"{category2.Id} {category2.Name}");
            }

            // Création de 2 contacts pour chaque catégorie
            Contact contact1 = new Contact("Nom de Toto", "Toto", "toto@test.com", 1);
            Contact contact2 = new Contact("Mouse", "Mickey", "mickey@test.com", 1);
            Contact contact3 = new Contact("Mouse", "Minnie", "minnie@test.com", 2);
            Contact contact4 = new Contact("Duck", "Donald", "donald@test.com", 2);
            Contact contact5 = new Contact("Duck", "Daisy", "daisy@test.com", 1002);
            Contact contact6 = new Contact("Nom de Dingo", "Dingo", "dingo@test.com", 1002);

            contactsService.Insert(contact1);
            contactsService.Insert(contact2);
            contactsService.Insert(contact3);
            contactsService.Insert(contact4);
            contactsService.Insert(contact5);
            contactsService.Insert(contact6);

            // Liste des contacts
            IEnumerable<Contact> contacts = contactsService.Get();

            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"{contact.Id} {contact.LastName} {contact.FirstName} {contact.Email} {contact.IdCategory}");
            }

            // Liste des contacts par catégorie
            IEnumerable<Category> listCategories = categoriesService.Get();
            foreach (Category category in listCategories)
            {
                Console.WriteLine($"Liste des contacts de la catégorie {category.Id}");
                IEnumerable<Contact> contactsByCategory = contactsService.GetByCategory(category.Id);

                foreach (Contact contact in contactsByCategory)
                {
                    Console.WriteLine($"{contact.Id} {contact.LastName} {contact.FirstName} {contact.Email} {contact.IdCategory}");
                }
                Console.WriteLine();
            }

            // Mise à jour d'un contact de la catégorie Personnel
            Contact contactPersonnel = contactsService.Get(1);
            contactPersonnel.Email = "toto@toto.fr";
            contactsService.Update(1, contactPersonnel);

            // Suppression d'un contact de la catégorie Autre
            contactsService.Delete(6);
        }
    }
}
