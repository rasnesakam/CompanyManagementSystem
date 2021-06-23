using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface IDomainService
    {
        Task<IDataResult<DomainDto>> Get(int domainId);
        Task<IDataResult<DomainListDto>> GetAll();

        Task<IResult> Add(DomainAddDto domainAddDto, string userName);
        Task<IResult> Update(DomainUpdateDto domainUpdateDto, string userName);

        Task<IResult> Delete(int domainId);
        Task<IResult> HardDelete(int domainId);
    }
}
