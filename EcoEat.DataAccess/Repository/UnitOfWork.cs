using EcoEat.DataAccess.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoEat.DataAccess.Repository
{
    public class UnitOfWork : iUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            Product = new ProductRepository(_db);
            Company= new CompanyRepository(_db);
        }
        public iCategoryRepository Category { get; private set; }
        public iDietTypeRepository CoverType { get; private set; }
        public iProductRepository Product { get; private set; }

        public iCompanyRepository Company { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
