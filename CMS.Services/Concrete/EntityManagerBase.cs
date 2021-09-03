using AutoMapper;
using CMS.Data.Abstract;
using CMS.Services.Abstract;
using CMS.Shared.Data.Abstract;
using CMS.Shared.Data.Concrete.EntityFramework;
using CMS.Shared.Entities.Abstract;
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
    public class EntityManagerBase<Entity> : IEntityService<Entity>
        where Entity : EntityBase, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityRepository<Entity> _repo;
        private readonly IMapper _mapper;

        public EntityManagerBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repo = _unitOfWork.GetRepository<Entity>();
        }

        public async Task<IDataResult<Entity>> Add(IODtobase dto)
        {
            try
            {
                var e = _mapper.Map<Entity>(dto);
                e = await _repo.AddAsync(e);
                await _unitOfWork.SaveAsync();
                return new DataResult<Entity>(ResultStatus.Success, e, "Veri eklendi");
            }
            catch(Exception e) {
                return new DataResult<Entity>(ResultStatus.Error, null, "Bir hata meydana geldi");
            }
        }

        public async Task<IResult> Delete(int entityId, string modifiedByName)
        {
            var res = await _repo.GetAsync(e => e.Id == entityId);
            if (res != null)
            {
                res.IsDeleted = true;
                res.ModifiedByName = modifiedByName;
                res.ModifiedDate = DateTime.Now;
                await _repo.UpdateAsync(res);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,"Veri silindi. İşlemi geri almak için çöp kutusuna göz atabilirsiniz");
            }
            else return new Result(ResultStatus.Error, "Veri silinemedi");
        }

        public async Task<IDataResult<Entity>> Get(int entityId)
        {
            var res = await _repo.GetAsync(e => e.Id == entityId);
            if (res != null) return new DataResult<Entity>(ResultStatus.Success, res);
            else return new DataResult<Entity>(ResultStatus.Error, null, "Veri bulunamadı");
        }

        public async Task<IDataResult<ICollection<Entity>>> GetAll(Expression<Func<Entity, bool>> predicate = null)
        {
            var res = await _repo.GetAllAsync();
            if (res.Count > 0)
            {
                return new DataResult<ICollection<Entity>>(ResultStatus.Success, res);
            }
            else return new DataResult<ICollection<Entity>>(ResultStatus.Error, res, "Veri bulunamadı");
        }

        public async Task<IDataResult<ICollection<Entity>>> GetAllByActiveAndNonDeleted()
        {
            return await GetAll(e => e.IsActive && !e.IsDeleted);
        }

        public async Task<IDataResult<ICollection<Entity>>> GetAllByDeleted()
        {
            return await GetAll(e => e.IsDeleted);
        }

        public async Task<IDataResult<ICollection<Entity>>> GetAllByNonDeleted()
        {
            return await GetAll(e => !e.IsDeleted);
        }

        public async Task<IDataResult<ICollection<Entity>>> GetAllByNonActive() 
        {
            return await GetAll(e => !e.IsActive);
        }

        public async Task<IResult> HardDelete(int entityId)
        {
            var e = await _repo.GetAsync(e=> e.Id == entityId);

            if (e != null)
            {
                await _repo.DeleteAsync(e);
                return new Result(ResultStatus.Success, "Veri kalıcı olarak silindi.");
            }
            else return new Result(ResultStatus.Error, "Veri silinemedi.");
        }

        public async Task<IDataResult<Entity>> Update(IODtobase dto)
        {
            try
            {
                var e = _mapper.Map<Entity>(dto);
                await _repo.UpdateAsync(e);
                await _unitOfWork.SaveAsync();
                return new DataResult<Entity>(ResultStatus.Success, e);
            }
            catch(Exception e)
            {
                return new DataResult<Entity>(ResultStatus.Error, null,"Veri güncellenemedi");
            }
        }
    }
}
