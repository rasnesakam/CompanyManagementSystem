using CMS.Entities.Abstract;
using CMS.Entities.Dtos;
using CMS.Shared.Entities.Abstract;
using CMS.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface ICommentService<CEntity,PEntity>
        where PEntity: EntityBase,new()
        where CEntity: CommentEntityBase<PEntity>
    {
        Task<IDataResult<CommentDto<CEntity,PEntity>>> Get(int commentId);
        Task<IDataResult<CommentListDto<CEntity,PEntity>>> GetAllByNonDeleted();
        Task<IDataResult<CommentListDto<CEntity,PEntity>>> GetAllByDeleted();
        Task<IDataResult<CommentListDto<CEntity,PEntity>>> GetAllByActiveAndNonDeleted();
        Task<IDataResult<CommentListDto<CEntity, PEntity>>> GetAll();

        Task<IDataResult<CommentDto<CEntity,PEntity>>> Add(CommentAddDto<CEntity, PEntity> commentAddDto, string userName);
        Task<IDataResult<CommentDto<CEntity,PEntity>>> Update(CommentUpdateDto<CEntity, PEntity> commentUpdateDto, string userName);

        Task<IResult> Delete(int commentId);
        Task<IResult> HardDelete(int commentId);
    }
}
