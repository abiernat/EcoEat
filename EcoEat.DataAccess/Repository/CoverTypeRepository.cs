using EcoEat.DataAccess.Repository.iRepository;
using EcoEat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoEat.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, iDietTypeRepository
    {
        private ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db= db;
        }


        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}
