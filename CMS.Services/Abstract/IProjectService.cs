using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface IProjectService
    {
        Task<IDataResult<ProjectDto>> Get(int projectId);
        Task<IDataResult<ProjectListDto>> GetAll();

        Task<IResult> Add(ProjectAddDto projectAddDto, string userName);
        Task<IResult> Update(ProjectUpdateDto projectUpdateDto, string userName);

        Task<IResult> Delete(int projectId);
        Task<IResult> HardDelete(int projectId);
    }
}
