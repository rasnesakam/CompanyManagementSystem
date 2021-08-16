using AutoMapper;
using CMS.Data.Abstract;
using CMS.Data.Concrete;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Services.Abstract;
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
    public class ProjectManager : IProjectService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProjectManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<ProjectDto>> Add(ProjectAddDto projectAddDto, string userName)
        {
            Project project = _mapper.Map<Project>(projectAddDto);
            project.CreateDate = DateTime.Now;
            project.ModifiedDate = DateTime.Now;
            project.CreatedByName = userName;
            project.ModifiedByName = userName;
            Project newProject = await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.SaveAsync();
            return new DataResult<ProjectDto>(ResultStatus.Success, new ProjectDto
            {
                Project = newProject,
                ResultStatus = ResultStatus.Success
            });

        }

        public async Task<IResult> Delete(int projectId, string userName)
        {
            var project = await _unitOfWork.Notes.GetAsync(m => m.Id == projectId);
            if (project != null)
            {
                project.ModifiedByName = userName;
                project.ModifiedDate = DateTime.Now;
                project.IsDeleted = true;
                await _unitOfWork.Notes.UpdateAsync(project);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Not bilgisi silindi. İşlemi geri almak için çöp kutusuna göz atın");
            }
            return new Result(ResultStatus.Error, "Not bilgisi silinirken bir hata oluştu");
        }

        public Task<IDataResult<ProjectDto>> Get(int projectId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ProjectListDto>> GetAll(Expression<Func<Project, bool>> predicate = null)
        {
            var projects = await _unitOfWork.Projects.GetAllAsync(predicate,null);
            if (projects != null)
            {
                return new DataResult<ProjectListDto>(ResultStatus.Success, new ProjectListDto
                {
                    Projects = projects,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProjectListDto>(ResultStatus.Error, new ProjectListDto
            {
                Projects = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan şirketler bulunamadı"
            });
        }

        public Task<IDataResult<ProjectListDto>> GetAllByActiveAndNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ProjectListDto>> GetAllByDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ProjectListDto>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ProjectDto>> Update(ProjectUpdateDto projectUpdateDto, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
