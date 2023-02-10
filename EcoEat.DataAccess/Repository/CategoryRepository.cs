using EcoEat.DataAccess.Repository.iRepository;
using EcoEat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoEat.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, iCategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db= db;
        }


        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
