using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<CommentDto>> Get(int commentId);
        Task<IDataResult<CommentListDto>> GetAll();

        Task<IResult> Add(CommentAddDto commentAddDto, string userName);
        Task<IResult> Update(CommentUpdateDto commentUpdateDto, string userName);

        Task<IResult> Delete(int commentId);
        Task<IResult> HardDelete(int commentId);
    }
}
