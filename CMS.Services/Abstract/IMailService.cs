using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface IMailService
    {
        Task<IDataResult<MailDto>> Get(int mailId);
        Task<IDataResult<MailListDto>> GetAll();
        Task<IDataResult<MailListDto>> GetAllByNonDeleted();
        Task<IDataResult<MailListDto>> GetAllByDeleted();
        Task<IDataResult<MailListDto>> GetAllByActiveAndNonDeleted();

        Task<IDataResult<MailDto>> Add(MailAddDto mailAddDto, string userName);
        Task<IDataResult<MailDto>> Update(MailUpdateDto mailUpdateDto, string userName);

        Task<IResult> Delete(int mailId, string userName);
        Task<IResult> HardDelete(int mailId);
    }
}
