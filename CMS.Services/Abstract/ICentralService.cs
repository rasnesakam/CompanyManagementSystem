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
        Task<IDataResult<CentralDto>> Get(int centralyId);
        Task<IDataResult<CentralListDto>> GetAll();

        Task<IResult> Add(CentralAddDto centralAddDto, string userName);
        Task<IResult> Update(CentralUpdateDto centralUpdateDto, string userName);

        Task<IResult> Delete(int centralId);
        Task<IResult> HardDelete(int centralId);
    }
}
