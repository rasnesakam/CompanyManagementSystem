using CMS.Shared.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Shared.Services.Abstract;
using CMS.Shared.Utilities.Results.Abstract;
using CMS.Shared.Entities.Dtos;
using CMS.Shared.Entities.Abstract;

namespace CMS.Shared.Services.Concrete
{
    public class ServiceBase<Entity> : IServiceBase<Entity>
        where Entity: EntityBase
    {
        public Task<IDataResult<DtoBase<Entity>>> Add(IODtobase addDto, string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int centralId, string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoBase<Entity>>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoListBase<Entity>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoListBase<Entity>>> GetAllByActiveAndNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoListBase<Entity>>> GetAllByDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoListBase<Entity>>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int centralId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoBase<Entity>>> Update(IODtobase updateDto, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
