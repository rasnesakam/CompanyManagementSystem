using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface ICompanyService
    {
        Task<IDataResult<CompanyDto>> Get(int companyId);
        Task<IDataResult<CompanyListDto>> GetAll();

        Task<IResult> Add(CompanyAddDto companyAddDto, string userName);
        Task<IResult> Update(CompanyUpdateDto companyUpdateDto, string userName);

        Task<IResult> Delete(int companyId);
        Task<IResult> HardDelete(int companyId);
    }
}
