using CMS.Data.Abstract;
using CMS.Shared.Data.Concrete.EntityFramework;
using CMS.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Concrete.EntityFramework.Repositories
{
    public class EFEntityBaseRepository: EFEntityRepositoryBase<EntityBase>, IEntityBaseRepository
    {
        public EFEntityBaseRepository(DbContext context) : base(context)
        {
        }
    }
}
