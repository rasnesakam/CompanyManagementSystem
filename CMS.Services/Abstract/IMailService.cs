using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface IMailService
    {
        Task<IDataResult<MailDto>> Get(int mailId);
        Task<IDataResult<MailListDto>> GetAll();

        Task<IResult> Add(MailAddDto mailAddDto, string userName);
        Task<IResult> Update(MailUpdateDto mailUpdateDto, string userName);

        Task<IResult> Delete(int mailId);
        Task<IResult> HardDelete(int mailId);
    }
}
