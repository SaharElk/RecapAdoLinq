﻿using ADOLinq.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOLinq.Client.Repositories
{
    public interface ICategoriesRepository
    {
        public IEnumerable<Category> Get();

        public Category Get(int id);

        public bool Insert(Category category);
    }
}
