using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface ICompanyService: IEntityService<Company>
    {
    }
}
