using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Shared.Entities.Dtos;
using CMS.Shared.Services.Abstract;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface IStatusService
    {
        Task<IDataResult<DtoBase<Status>>> Get(int id);
        Task<IDataResult<DtoListBase<Status>>> GetAll();
        Task<IDataResult<DtoListBase<Status>>> GetAllByNonDeleted();
        Task<IDataResult<DtoListBase<Status>>> GetAllByDeleted();
        Task<IDataResult<DtoListBase<Status>>> GetAllByActiveAndNonDeleted();

        Task<IDataResult<DtoBase<Status>>> Add(StatusAddDto addDto, string userName);
        Task<IDataResult<DtoBase<Status>>> Update(StatusUpdateDto updateDto, string userName);

        Task<IResult> Delete(int id, string userName);
        Task<IResult> HardDelete(int id);
    }
}
