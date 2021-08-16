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
    public class TagManager : ITagService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TagManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IDataResult<DtoBase<Tag>>> Add(TagAddDto addDto, string userName)
        {
            var newTag = _mapper.Map<Tag>(addDto);
            newTag.CreatedByName = userName;
            newTag.ModifiedByName = userName;
            newTag = await _unitOfWork.Tags.AddAsync(newTag);
            await _unitOfWork.SaveAsync();
            return new DataResult<DtoBase<Tag>>(ResultStatus.Success, new DtoBase<Tag>
            {
                Data = newTag,
                ResultStatus = ResultStatus.Success
            });
        }

        public Task<IResult> Delete(int centralId, string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoBase<Tag>>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<DtoListBase<Tag>>> GetAll()
        {
            var tags = await _unitOfWork.Tags.GetAllAsync(null);
            if (tags.Count > -1) return new DataResult<DtoListBase<Tag>>(ResultStatus.Success, new DtoListBase<Tag>
            {
                Datas = tags,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<DtoListBase<Tag>>(ResultStatus.Error, new DtoListBase<Tag>
            {
                Datas = null,
                ResultStatus = ResultStatus.Error,
                Message = "Veriler bulunamadı"
            });
        }

        public async Task<IDataResult<DtoListBase<Tag>>> GetAllByActiveAndNonDeleted()
        {
            var tags = await _unitOfWork.Tags.GetAllAsync( t => t.IsActive && !t.IsDeleted);
            if (tags.Count > -1) return new DataResult<DtoListBase<Tag>>(ResultStatus.Success, new DtoListBase<Tag>
            {
                Datas = tags,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<DtoListBase<Tag>>(ResultStatus.Error, new DtoListBase<Tag>
            {
                Datas = null,
                ResultStatus = ResultStatus.Error,
                Message = "Veriler bulunamadı"
            });
        }

        public async Task<IDataResult<DtoListBase<Tag>>> GetAllByDeleted()
        {
            var tags = await _unitOfWork.Tags.GetAllAsync(t => t.IsDeleted);
            if (tags.Count > -1) return new DataResult<DtoListBase<Tag>>(ResultStatus.Success, new DtoListBase<Tag>
            {
                Datas = tags,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<DtoListBase<Tag>>(ResultStatus.Error, new DtoListBase<Tag>
            {
                Datas = null,
                ResultStatus = ResultStatus.Error,
                Message = "Veriler bulunamadı"
            });
        }

        public async Task<IDataResult<DtoListBase<Tag>>> GetAllByNonDeleted()
        {
            var tags = await _unitOfWork.Tags.GetAllAsync(t => !t.IsDeleted);
            if (tags.Count > -1) return new DataResult<DtoListBase<Tag>>(ResultStatus.Success, new DtoListBase<Tag>
            {
                Datas = tags,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<DtoListBase<Tag>>(ResultStatus.Error, new DtoListBase<Tag>
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

        public Task<IDataResult<DtoBase<Tag>>> Update(TagUpdateDto updateDto, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
