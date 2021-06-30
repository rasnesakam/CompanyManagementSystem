using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserDto>> Get(int userId);
        Task<IDataResult<UserListDto>> GetAll();
        Task<IDataResult<UserListDto>> GetAllByNonDeleted();
        Task<IDataResult<UserListDto>> GetAllByDeleted();
        Task<IDataResult<UserListDto>> GetAllByActiveAndNonDeleted();

        Task<IDataResult<UserDto>> Add(UserAddDto userAddDto, string userName);
        Task<IDataResult<UserDto>> Update(UserUpdateDto userUpdateDto, string userName);

        Task<IResult> Delete(int userId);
        Task<IResult> HardDelete(int userId);
    }
}