using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Concrete
{
    public class CentralManager : ICentralService
    {
        public Task<IResult> Add(CentralAddDto centralAddDto, string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int centralId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CentralDto>> Get(int centralyId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CentralListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int centralId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(CentralUpdateDto centralUpdateDto, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
