using ADOLinq.Client.Data;
using ADOLinq.Client.Mappers;
using ADOLinq.Client.Repositories;
using System.Collections.Generic;
using System.Linq;
using G = ADOLinq.Services;

namespace ADOLinq.Client.Services
{
    public class CategoriesService : ICategoriesRepository
    {
        private readonly G.CategoriesService _categoriesService;

        public CategoriesService(G.CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public IEnumerable<Category> Get() 
        {
            return _categoriesService.Get().Select(c => c.ToClient());
        }

        public Category Get(int id)
        {
            return _categoriesService.Get(id).ToClient();
        }

        public bool Insert(Category category)
        {
            return _categoriesService.Insert(category.ToGlobal());
        }
    }
}
