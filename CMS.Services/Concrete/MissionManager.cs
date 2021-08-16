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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Concrete
{
    public class MissionManager : IMissionService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public MissionManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<DtoBase<Mission>>> Add(MissionAddDto missionAddDto, string userName)
        {
            var mission = _mapper.Map<Mission>(missionAddDto);
            mission.CreatedByName = userName;
            mission.ModifiedByName = userName;

            mission = await _unitOfWork.Missions.AddAsync(mission);
            await _unitOfWork.SaveAsync();
            return new DataResult<DtoBase<Mission>>(ResultStatus.Success,new DtoBase<Mission>
            {
                Data = mission,
                ResultStatus = ResultStatus.Success
            });
        }

        public Task<IResult> Delete(int missionId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoBase<Mission>>> Get(int missionId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<DtoListBase<Mission>>> GetAll(Expression<Func<Mission, bool>> predicate = null)
        {
            var missions = await _unitOfWork.Missions.GetAllAsync(predicate, c => c.MissionComments);
            if (missions.Count > 0)
            {
                return new DataResult<DtoListBase<Mission>>(ResultStatus.Success, new DtoListBase<Mission>
                {
                    Datas = missions,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<DtoListBase<Mission>>(ResultStatus.Error, new DtoListBase<Mission>
            {
                ResultStatus = ResultStatus.Error,
                Datas = null
            });
        }

        public Task<IDataResult<DtoListBase<Mission>>> GetAllByActiveAndNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoListBase<Mission>>> GetAllByDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoListBase<Mission>>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int missionId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DtoBase<Mission>>> Update(MissionUpdateDto missionUpdateDto, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
