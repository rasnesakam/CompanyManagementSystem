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
        Task<IDataResult<Entity>> Get(int entityId);
        Task<IDataResult<ICollection<Entity>>> GetAll(Expression<Func<Entity, bool>> predicate = null);
        Task<IDataResult<ICollection<Entity>>> GetAllByNonDeleted();
        Task<IDataResult<ICollection<Entity>>> GetAllByDeleted();
        Task<IDataResult<ICollection<Entity>>> GetAllByActiveAndNonDeleted();
        Task<IDataResult<ICollection<Entity>>> GetAllByNonActive();

        Task<IDataResult<Entity>> Add(IODtobase dto);
        Task<IDataResult<Entity>> Update(IODtobase dto);

        Task<IResult> Delete(int entityId, string modifiedByName);
        Task<IResult> HardDelete(int entityId);
    }
}
