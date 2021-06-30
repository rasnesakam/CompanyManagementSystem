using CMS.Shared.Utilities.Results.Abstract;
using CMS.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface ICentralService
    {
        Task<IDataResult<CentralDto>> Get(int centralId);
        Task<IDataResult<CentralListDto>> GetAll();
        Task<IDataResult<CentralListDto>> GetAllByNonDeleted();
        Task<IDataResult<CentralListDto>> GetAllByDeleted();
        Task<IDataResult<CentralListDto>> GetAllByActiveAndNonDeleted();

        Task<IDataResult<CentralDto>> Add(CentralAddDto centralAddDto, string userName);
        Task<IDataResult<CentralDto>> Update(CentralUpdateDto centralUpdateDto, string userName);

        Task<IResult> Delete(int centralId,string userName);
        Task<IResult> HardDelete(int centralId);
    }
}
