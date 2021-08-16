
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
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
    public interface IMissionService
    {
        Task<IDataResult<DtoBase<Mission>>> Get(int missionId);
        Task<IDataResult<DtoListBase<Mission>>> GetAll(Expression<Func<Mission, bool>> predicate = null);
        Task<IDataResult<DtoListBase<Mission>>> GetAllByNonDeleted();
        Task<IDataResult<DtoListBase<Mission>>> GetAllByDeleted();
        Task<IDataResult<DtoListBase<Mission>>> GetAllByActiveAndNonDeleted();

        Task<IDataResult<DtoBase<Mission>>> Add(MissionAddDto missionAddDto, string userName);
        Task<IDataResult<DtoBase<Mission>>> Update(MissionUpdateDto missionUpdateDto, string userName);

        Task<IResult> Delete(int missionId);
        Task<IResult> HardDelete(int missionId);
    }
}
