using CMS.Shared.Entities.Abstract;
using CMS.Shared.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface IEntityService<Entity>
        where Entity: EntityBase
    {
        Task<IDataResult<Entity>> Get(int entityId, params Expression<Func<Entity, object>>[] includeProperty);
        Task<IDataResult<ICollection<Entity>>> GetAll(Expression<Func<Entity, bool>> predicate = null, params Expression<Func<Entity, object>>[] includeProperty);
        Task<IDataResult<ICollection<Entity>>> GetAllByNonDeleted(params Expression<Func<Entity, object>>[] includeProperty);
        Task<IDataResult<ICollection<Entity>>> GetAllByDeleted(params Expression<Func<Entity, object>>[] includeProperty);
        Task<IDataResult<ICollection<Entity>>> GetAllByActiveAndNonDeleted(params Expression<Func<Entity, object>>[] includeProperty);
        Task<IDataResult<ICollection<Entity>>> GetAllByNonActive(params Expression<Func<Entity, object>>[] includeProperty);

        Task<IDataResult<Entity>> Add(AddDtoBase dto);
        Task<IDataResult<Entity>> Update(int id, AddDtoBase dto);

        Task<IResult> Delete(int entityId, string modifiedByName);
        Task<IResult> HardDelete(int entityId);
    }
}
