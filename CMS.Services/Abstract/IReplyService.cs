using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface IReplyService
    {
        Task<IDataResult<ReplyDto>> Get(int replyId);
        Task<IDataResult<ReplyListDto>> GetAll();

        Task<IResult> Add(ReplyAddDto replyAddDto, string userName);
        Task<IResult> Update(ReplyUpdateDto replyUpdateDto, string userName);

        Task<IResult> Delete(int replyId);
        Task<IResult> HardDelete(int replyId);
    }
}
