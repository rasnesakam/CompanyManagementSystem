using CMS.Shared.Data.Abstract;
using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Abstract
{
    public interface IEntityBaseRepository: IEntityRepository<EntityBase>
    {
    }
}
