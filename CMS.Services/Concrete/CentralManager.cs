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
    public class CentralManager : ICentralService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CentralManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<CentralDto>> Add(CentralAddDto centralAddDto, string userName)
        {
            var central = _mapper.Map<Central>(centralAddDto);
            central.CreatedByName = userName;
            central.ModifiedByName = userName;
            central.CreateDate = DateTime.Now;
            central.ModifiedDate = DateTime.Now;
            await _unitOfWork.Centrals.AddAsync(central);
            await _unitOfWork.SaveAsync();
            return new DataResult<CentralDto>(ResultStatus.Success, message: $"\"{central.Name}\" adlı santral başarıyla eklendi", data: new CentralDto
            {
                Central = central,
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IResult> Delete(int centralId,string userName)
        {
            var central = await _unitOfWork.Centrals.GetAsync( c => c.Id == centralId);
            if (central != null)
            {
                central.IsDeleted = true;
                central.ModifiedByName = userName;
                central.ModifiedDate = DateTime.Now;
                await _unitOfWork.Centrals.UpdateAsync(central);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,message:"Santral başarıyla silindi. Çöp kutusundan geri alabilirsiniz.");
            }
            return new Result(ResultStatus.Error, message:"Santrali silmeye çalışırken bir hata meydana geldi.");

        }

        public async Task<IDataResult<CentralDto>> Get(int centralId)
        {
            var central = await _unitOfWork.Centrals.GetAsync(c => c.Id == centralId, c => c.Parent);
            if (central != null) return new DataResult<CentralDto>(ResultStatus.Success, new CentralDto
            {
                Central = central,
                ResultStatus = ResultStatus.Success
            });
            else return new DataResult<CentralDto>(ResultStatus.Error, null, "Aranan santral bulunamadı");
        }

        public async Task<IDataResult<CentralListDto>> GetAll()
        {
            var centrals = await _unitOfWork.Centrals.GetAllAsync(null, c => c.Parent);
            if (centrals.Count > -1) return new DataResult<CentralListDto>(ResultStatus.Success, new CentralListDto
            {
                Centrals = centrals,
                ResultStatus = ResultStatus.Success
            });

            else return new DataResult<CentralListDto>(ResultStatus.Error, message: "Santral bulunamadı", data: new CentralListDto
            {
                Centrals = null,
                ResultStatus = ResultStatus.Error,
                Message = "Santral bulunamadı"
            });
        }

        public async Task<IDataResult<CentralListDto>> GetAllByActiveAndNonDeleted()
        {
            var centrals = await _unitOfWork.Centrals.GetAllAsync(c => c.IsActive && !c.IsDeleted, c => c.Parent);
            if (centrals.Count > -1) return new DataResult<CentralListDto>(ResultStatus.Success, new CentralListDto
            {
                Centrals = centrals,
                ResultStatus = ResultStatus.Success
            });

            else return new DataResult<CentralListDto>(ResultStatus.Error, message: "Santral bulunamadı", data: new CentralListDto
            {
                Centrals = null,
                ResultStatus = ResultStatus.Error,
                Message = "Santral bulunamadı"
            });
        }

        public async Task<IDataResult<CentralListDto>> GetAllByDeleted()
        {
            var centrals = await _unitOfWork.Centrals.GetAllAsync(c => c.IsDeleted, c => c.Parent);
            if (centrals.Count > -1) return new DataResult<CentralListDto>(ResultStatus.Success, new CentralListDto
            {
                Centrals = centrals,
                ResultStatus = ResultStatus.Success
            });

            else return new DataResult<CentralListDto>(ResultStatus.Error, message: "Santral bulunamadı", data: new CentralListDto
            {
                Centrals = null,
                ResultStatus = ResultStatus.Error,
                Message = "Santral bulunamadı"
            });
        }

        public async Task<IDataResult<CentralListDto>> GetAllByNonDeleted()
        {
            var centrals = await _unitOfWork.Centrals.GetAllAsync(c => !c.IsDeleted, c => c.Parent);
            if (centrals.Count > -1) return new DataResult<CentralListDto>(ResultStatus.Success, new CentralListDto
            {
                Centrals = centrals,
                ResultStatus = ResultStatus.Success
            });

            else return new DataResult<CentralListDto>(ResultStatus.Error, message: "Santral bulunamadı", data: new CentralListDto
            {
                Centrals = null,
                ResultStatus = ResultStatus.Error,
                Message = "Santral bulunamadı"
            });
        }

        public async Task<IResult> HardDelete(int centralId)
        {
            var central = await _unitOfWork.Centrals.GetAsync(c => c.Id == centralId);
            if (central != null)
            {
                await _unitOfWork.Centrals.DeleteAsync(central);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Santral kalıcı olarak silindi");
            }
            else return new Result(ResultStatus.Error, "Santral silinirken hata oluştu");
        }

        public async Task<IDataResult<CentralDto>> Update(CentralUpdateDto centralUpdateDto, string userName)
        {
            var central = _mapper.Map<Central>(centralUpdateDto);
            central.ModifiedByName = userName;
            central.ModifiedDate = DateTime.Now;
            var updatedCentral = await _unitOfWork.Centrals.UpdateAsync(central);
            await _unitOfWork.SaveAsync();
            return new DataResult<CentralDto>(ResultStatus.Success, new CentralDto
            {
                Central = updatedCentral,
                ResultStatus = ResultStatus.Success,
                Message = "Santral başarıyla güncellendi"
            });
        }
    }
}
