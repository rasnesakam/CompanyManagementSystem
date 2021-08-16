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
    public interface ITagService
    {
        Task<IDataResult<DtoBase<Tag>>> Get(int id);
        Task<IDataResult<DtoListBase<Tag>>> GetAll();
        Task<IDataResult<DtoListBase<Tag>>> GetAllByNonDeleted();
        Task<IDataResult<DtoListBase<Tag>>> GetAllByDeleted();
        Task<IDataResult<DtoListBase<Tag>>> GetAllByActiveAndNonDeleted();

        Task<IDataResult<DtoBase<Tag>>> Add(TagAddDto addDto, string userName);
        Task<IDataResult<DtoBase<Tag>>> Update(TagUpdateDto updateDto, string userName);

        Task<IResult> Delete(int id, string userName);
        Task<IResult> HardDelete(int id);
    }
}
