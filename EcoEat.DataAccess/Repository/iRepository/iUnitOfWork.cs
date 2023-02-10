using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoEat.DataAccess.Repository.iRepository
{
    public interface iUnitOfWork
    {
        iCategoryRepository Category { get; }
        iDietTypeRepository CoverType { get; }
        iProductRepository Product { get; }
        iCompanyRepository Company { get; }

        void Save();
    }
}
