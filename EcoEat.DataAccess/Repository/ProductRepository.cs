using EcoEat.DataAccess.Repository.iRepository;
using EcoEat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoEat.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, iProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db= db;
        }


        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name= obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.Producer = obj.Producer;
                objFromDb.Country = obj.Country;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price2 = obj.Price2;
                objFromDb.Price10 = obj.Price10;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                if(obj.ImageUrl!= null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
