using AutoMapper;
using CMS.Data.Abstract;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using CMS.Shared.Entities.Dtos;
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
    public class StatusManager: IStatusService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public StatusManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<DtoBase<Status>>> Add(StatusAddDto addDto, string userName)
        {
            var status = _mapper.Map<Status>(addDto);
            status.ModifiedByName = userName;
            status.CreatedByName = userName;
            var nstatus = await _unitOfWork.Statuses.AddAsync(status);
            await _unitOfWork.SaveAsync();
            return new DataResult<DtoBase<Status>>(ResultStatus.Success,new DtoBase<Status>
            {
                ResultStatus = ResultStatus.Success,
                Data = nstatus
            });
        }

        public Task<IResult> Delete(int centralId, string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<DtoBase<Status>>> Get(int id)
        {
            var status = await _unitOfWork.Statuses.GetAsync(s=> s.Id == id);
            if (status != null) return new DataResult<DtoBase<Status>>(ResultStatus.Success, new DtoBase<Status>
            {
                Data = status,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<DtoBase<Status>>(ResultStatus.Error, new DtoBase<Status>
            {
                Data = null,
                ResultStatus = ResultStatus.Error,
                Message = "Veriler bulunamadı"
            });
        }

        public async Task<IDataResult<DtoListBase<Status>>> GetAll()
        {
            var statuses = await _unitOfWork.Statuses.GetAllAsync(null);
            if (statuses.Count > -1) return new DataResult<DtoListBase<Status>>(ResultStatus.Success,new DtoListBase<Status>
            {
                Datas = statuses,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<DtoListBase<Status>>(ResultStatus.Error, new DtoListBase<Status>
            {
                Datas = null,
                ResultStatus = ResultStatus.Error,
                Message = "Veriler bulunamadı"
            });
        }

        public async Task<IDataResult<DtoListBase<Status>>> GetAllByActiveAndNonDeleted()
        {
            var statuses = await _unitOfWork.Statuses.GetAllAsync(s => s.IsActive && !s.IsDeleted);
            if (statuses.Count > -1) return new DataResult<DtoListBase<Status>>(ResultStatus.Success, new DtoListBase<Status>
            {
                Datas = statuses,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<DtoListBase<Status>>(ResultStatus.Error, new DtoListBase<Status>
            {
                Datas = null,
                ResultStatus = ResultStatus.Error,
                Message = "Veriler bulunamadı"
            });
        }

        public async Task<IDataResult<DtoListBase<Status>>> GetAllByDeleted()
        {
            var statuses = await _unitOfWork.Statuses.GetAllAsync(s => s.IsDeleted);
            if (statuses.Count > -1) return new DataResult<DtoListBase<Status>>(ResultStatus.Success, new DtoListBase<Status>
            {
                Datas = statuses,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<DtoListBase<Status>>(ResultStatus.Error, new DtoListBase<Status>
            {
                Datas = null,
                ResultStatus = ResultStatus.Error,
                Message = "Veriler bulunamadı"
            });
        }

        public async Task<IDataResult<DtoListBase<Status>>> GetAllByNonDeleted()
        {
            var statuses = await _unitOfWork.Statuses.GetAllAsync(s => !s.IsDeleted);
            if (statuses.Count > -1) return new DataResult<DtoListBase<Status>>(ResultStatus.Success, new DtoListBase<Status>
            {
                Datas = statuses,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<DtoListBase<Status>>(ResultStatus.Error, new DtoListBase<Status>
            {
                Datas = null,
                ResultStatus = ResultStatus.Error,
                Message = "Veriler bulunamadı"
            });
        }

        public Task<IResult> HardDelete(int centralId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoBase<Status>>> Update(StatusUpdateDto updateDto, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
