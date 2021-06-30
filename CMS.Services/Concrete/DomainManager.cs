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
    public class DomainManager : IDomainService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DomainManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<DomainDto>> Add(DomainAddDto domainAddDto, string userName)
        {
            var domain = _mapper.Map<Domain>(domainAddDto);
            domain.CreatedByName = userName;
            domain.CreateDate= DateTime.Now;
            var addedDomain = await _unitOfWork.Domains.AddAsync(domain);
            await _unitOfWork.SaveAsync();
            return new DataResult<DomainDto>(ResultStatus.Success, new DomainDto
            {
                ResultStatus = ResultStatus.Success,
                Message = "Domain adı başarıyla eklendi",
                Domain = addedDomain
            });
        }

        public async Task<IResult> Delete(int domainId,string userName)
        {
            var domain = await _unitOfWork.Domains.GetAsync(d => d.Id == domainId);
            if (domain != null)
            {
                domain.ModifiedByName = userName;
                domain.ModifiedDate = DateTime.Now;
                domain.IsDeleted = true;

                await _unitOfWork.Domains.UpdateAsync(domain);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Domain adı başarıyla silindi. İşleminizi geri almak için çöp kutusuna göz atın");
            }
            return new Result(ResultStatus.Error, "Domain adı silinirken bir hata oluştu. Lütfen daha sonra tekrar deneyin");
            
        }

        public async Task<IDataResult<DomainDto>> Get(int domainId)
        {
            var domain = await _unitOfWork.Domains.GetAsync(d => d.Id == domainId, d => d.Parent);
            if (domain != null) return new DataResult<DomainDto>(ResultStatus.Success, new DomainDto
            {
                Domain = domain,
                ResultStatus = ResultStatus.Success
            });
            else return new DataResult<DomainDto>(ResultStatus.Error, message: "Aranan domain adı bulunamadı", data: new DomainDto
            {
                Domain = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan domain adı bulunamadı"
            });
        }

        public async Task<IDataResult<DomainListDto>> GetAll()
        {
            var domains = await _unitOfWork.Domains.GetAllAsync(null,d => d.Parent);
            if (domains.Count > -1) return new DataResult<DomainListDto>(ResultStatus.Success, new DomainListDto
            {
                Domains = domains,
                ResultStatus = ResultStatus.Success
            });
            else return new DataResult<DomainListDto>(ResultStatus.Error, message: "Aranan domain adları bulunamadı", data: new DomainListDto
            {
                Domains = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan domain adları bulunamadı"
            });
        }

        public async Task<IDataResult<DomainListDto>> GetAllByActiveAndNonDeleted()
        {
            var domains = await _unitOfWork.Domains.GetAllAsync(d => d.IsActive && !d.IsDeleted, d => d.Parent);
            if (domains.Count > -1) return new DataResult<DomainListDto>(ResultStatus.Success, new DomainListDto
            {
                Domains = domains,
                ResultStatus = ResultStatus.Success
            });
            else return new DataResult<DomainListDto>(ResultStatus.Error, message: "Aranan domain adları bulunamadı", data: new DomainListDto
            {
                Domains = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan domain adları bulunamadı"
            });
        }

        public async Task<IDataResult<DomainListDto>> GetAllByDeleted()
        {
            var domains = await _unitOfWork.Domains.GetAllAsync(d => d.IsDeleted, d => d.Parent);
            if (domains.Count > -1) return new DataResult<DomainListDto>(ResultStatus.Success, new DomainListDto
            {
                Domains = domains,
                ResultStatus = ResultStatus.Success
            });
            else return new DataResult<DomainListDto>(ResultStatus.Error, message: "Aranan domain adları bulunamadı", data: new DomainListDto
            {
                Domains = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan domain adları bulunamadı"
            });
        }

        public async Task<IDataResult<DomainListDto>> GetAllByNonDeleted()
        {
            var domains = await _unitOfWork.Domains.GetAllAsync(d => !d.IsDeleted, d => d.Parent);
            if (domains.Count > -1) return new DataResult<DomainListDto>(ResultStatus.Success, new DomainListDto
            {
                Domains = domains,
                ResultStatus = ResultStatus.Success
            });
            else return new DataResult<DomainListDto>(ResultStatus.Error, message: "Aranan domain adları bulunamadı", data: new DomainListDto
            {
                Domains = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan domain adları bulunamadı"
            });
        }

        public async Task<IResult> HardDelete(int domainId)
        {
            var domain = await _unitOfWork.Domains.GetAsync(d => d.Id == domainId);
            if (domain != null)
            {
                await _unitOfWork.Domains.DeleteAsync(domain);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Domain adı başarıyla silindi. İşlemi geri almak için çöp kutusuna bakın");
            }
            else return new Result(ResultStatus.Error,"Domain adı silinemedi. Lütfen daha sonra tekrar deneyin");
        }

        public async Task<IDataResult<DomainDto>> Update(DomainUpdateDto domainUpdateDto, string userName)
        {
            var domain = _mapper.Map<Domain>(domainUpdateDto);
            domain.ModifiedByName = userName;
            domain.ModifiedDate = DateTime.Now;
            var newDomain = await _unitOfWork.Domains.UpdateAsync(domain);
            await _unitOfWork.SaveAsync();
            return new DataResult<DomainDto>(ResultStatus.Success, message: "Domain adı başarıyla güncellendi", data: new DomainDto
            {
                ResultStatus = ResultStatus.Success,
                Domain = newDomain
            });
        }
    }
}
