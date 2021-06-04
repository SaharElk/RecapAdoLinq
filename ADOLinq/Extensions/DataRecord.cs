using ADOLinq.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOLinq.Extensions
{
    public static class DataRecord
    {
        public static Category ToCategory(this IDataRecord record)
        {
            return new Category() 
            { 
                Id = (int)record["Id"], 
                Name = record["Name"].ToString() 
            };
        }

        public static Contact ToContact(this IDataRecord record)
        {
            return new Contact
            {
                Id = (int)record["Id"],
                LastName = record["LastName"].ToString(),
                FirstName = record["FirstName"].ToString(),
                Email = record["Email"].ToString(),
                IdCategory = (int)record["IdCategory"]
            };
        }
    }
}
