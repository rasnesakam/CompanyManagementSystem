using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface ICompanyService
    {
        Task<IDataResult<CompanyDto>> Get(int companyId);
        Task<IDataResult<CompanyListDto>> GetAll(Expression<Func<Company, bool>> predicate = null);
        Task<IDataResult<CompanyListDto>> GetAllByNonDeleted();
        Task<IDataResult<CompanyListDto>> GetAllByDeleted();
        Task<IDataResult<CompanyListDto>> GetAllByActiveAndNonDeleted();

        Task<IDataResult<CompanyDto>> Add(CompanyAddDto companyAddDto, string userName);
        Task<IDataResult<CompanyDto>> Update(CompanyUpdateDto companyUpdateDto, string userName);

        Task<IResult> Delete(int companyId,string userName);
        Task<IResult> HardDelete(int companyId);
    }
}
