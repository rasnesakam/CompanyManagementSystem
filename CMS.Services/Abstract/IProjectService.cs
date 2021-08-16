using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface IProjectService
    {
        Task<IDataResult<ProjectDto>> Get(int projectId);
        Task<IDataResult<ProjectListDto>> GetAll(Expression<Func<Project, bool>> predicate = null);
        Task<IDataResult<ProjectListDto>> GetAllByNonDeleted();
        Task<IDataResult<ProjectListDto>> GetAllByDeleted();
        Task<IDataResult<ProjectListDto>> GetAllByActiveAndNonDeleted();

        Task<IDataResult<ProjectDto>> Add(ProjectAddDto projectAddDto, string userName);
        Task<IDataResult<ProjectDto>> Update(ProjectUpdateDto projectUpdateDto, string userName);

        Task<IResult> Delete(int projectId, string userName);
        Task<IResult> HardDelete(int projectId);
    }
}
