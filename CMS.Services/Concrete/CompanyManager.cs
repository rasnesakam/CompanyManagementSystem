using AutoMapper;
using CMS.Data.Abstract;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Results.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using CMS.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CompanyManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CompanyDto>> Add(CompanyAddDto companyAddDto, string userName)
        {
            var company = _mapper.Map<Company>(companyAddDto);
            company.CreatedByName = userName;
            company.CreateDate = DateTime.Now;
            var newCompany = await _unitOfWork.Companies.AddAsync(company);
            await _unitOfWork.SaveAsync();
            return new DataResult<CompanyDto>(ResultStatus.Success, new CompanyDto
            {
                ResultStatus = ResultStatus.Success,
                Company = company
            });
        }

        public async Task<IResult> Delete(int companyId, string userName)
        {
            var company = await _unitOfWork.Companies.GetAsync(c => c.Id == companyId);
            if (company != null)
            {
                company.IsDeleted = true;
                company.ModifiedByName = userName;
                company.ModifiedDate = DateTime.Now;
                await _unitOfWork.Companies.UpdateAsync(company);
                return new Result(ResultStatus.Success, "Şirket başarıyla silindi. İşleminizi geri almak için lütfen çöp kutusuna göz atın");
            }
            return new Result(ResultStatus.Error, "Şirket silinirken bir hata oluştu.");
        }

        public async Task<IDataResult<CompanyDto>> Get(int companyId)
        {
            var company = await _unitOfWork.Companies.GetAsync(c => c.Id == companyId);
            if (company != null)
            {
                return new DataResult<CompanyDto>(ResultStatus.Success, new CompanyDto
                {
                    Company = company,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CompanyDto>(ResultStatus.Error, new CompanyDto
            {
                Company = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan şirket bulunamadı"
            });
        }

        public async Task<IDataResult<CompanyListDto>> GetAll()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync(null);
            if (companies != null)
            {
                return new DataResult<CompanyListDto>(ResultStatus.Success, new CompanyListDto
                {
                    Companies = companies,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CompanyListDto>(ResultStatus.Error, new CompanyListDto
            {
                Companies = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan şirketler bulunamadı"
            });
        }

        public async Task<IDataResult<CompanyListDto>> GetAllByActiveAndNonDeleted()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync(c => c.IsActive && !c.IsDeleted);
            if (companies != null)
            {
                return new DataResult<CompanyListDto>(ResultStatus.Success, new CompanyListDto
                {
                    Companies = companies,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CompanyListDto>(ResultStatus.Error, new CompanyListDto
            {
                Companies = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan şirketler bulunamadı"
            });
        }

        public async Task<IDataResult<CompanyListDto>> GetAllByDeleted()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync(c => c.IsDeleted);
            if (companies != null)
            {
                return new DataResult<CompanyListDto>(ResultStatus.Success, new CompanyListDto
                {
                    Companies = companies,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CompanyListDto>(ResultStatus.Error, new CompanyListDto
            {
                Companies = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan şirketler bulunamadı"
            });
        }

        public async Task<IDataResult<CompanyListDto>> GetAllByNonDeleted()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync(c => !c.IsDeleted);
            if (companies != null)
            {
                return new DataResult<CompanyListDto>(ResultStatus.Success, new CompanyListDto
                {
                    Companies = companies,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CompanyListDto>(ResultStatus.Error, new CompanyListDto
            {
                Companies = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan şirketler bulunamadı"
            });
        }

        public async Task<IResult> HardDelete(int companyId)
        {
            var company = await _unitOfWork.Companies.GetAsync(c => c.Id == companyId);
            if (company != null)
            {
                await _unitOfWork.Companies.DeleteAsync(company);
                await _unitOfWork.SaveAsync();
                return new Result( ResultStatus.Success, "Şirket kalıcı olarak silindi.");
            }
            return new Result(ResultStatus.Error, "Şirket silinemedi");
        }

        public async Task<IDataResult<CompanyDto>> Update(CompanyUpdateDto companyUpdateDto, string userName)
        {
            var company = _mapper.Map<Company>(companyUpdateDto);
            company.ModifiedByName = userName;
            company.ModifiedDate = DateTime.Now;
            var updatedCompany = await _unitOfWork.Companies.UpdateAsync(company);
            await _unitOfWork.SaveAsync();
            return new DataResult<CompanyDto>(ResultStatus.Success, new CompanyDto
            {
                Company = updatedCompany,
                ResultStatus = ResultStatus.Success,
                Message = "Şirket verileri başarılı bir şekilde güncellendi"
            });

        }
    }
}
