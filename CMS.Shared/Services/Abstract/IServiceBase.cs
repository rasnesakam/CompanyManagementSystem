using CMS.Shared.Entities.Abstract;
using CMS.Shared.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Shared.Services.Abstract
{
    public interface IServiceBase<Entity>
        where Entity: EntityBase
    {
        Task<IDataResult<DtoBase<Entity>>> Get(int id);
        Task<IDataResult<DtoListBase<Entity>>> GetAll();
        Task<IDataResult<DtoListBase<Entity>>> GetAllByNonDeleted();
        Task<IDataResult<DtoListBase<Entity>>> GetAllByDeleted();
        Task<IDataResult<DtoListBase<Entity>>> GetAllByActiveAndNonDeleted();

        Task<IDataResult<DtoBase<Entity>>> Add(IODtobase addDto, string userName);
        Task<IDataResult<DtoBase<Entity>>> Update(IODtobase updateDto, string userName);

        Task<IResult> Delete(int centralId, string userName);
        Task<IResult> HardDelete(int centralId);
    }
}
