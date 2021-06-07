using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOLinq.Client.Data
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        internal Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
