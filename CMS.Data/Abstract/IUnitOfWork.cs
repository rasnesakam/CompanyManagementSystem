using CMS.Shared.Data.Abstract;
using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IEntityBaseRepository BaseRepository { get; }
        ITagRepository Tags { get; }
        IStatusRepository Statuses { get; }
        IReminderRepository Reminders { get; }
        IProjectUserRepository ProjectUsers{ get; }
        IProjectTagRepository ProjectTags { get; }
        IProjectRepository Projects { get; }
        INoteRepository Notes { get; }
        IMissionUserRepository MissionUsers { get; }
        IMissionTagRepository MissionTags { get; }
        IMissionRepository Missions { get; }
        IMissionCommentRepository MissionComments { get; }
        IMissionCommentDocRepository MissionCommentDocs { get; }
        IMCommentReplyRepository MissionCommentReplies { get; }
        IMCReplyDocRepository MissionCommentReplyDocs { get; }
        IMailRepository Mails { get; }
        IDomainRepository Domains { get; }
        ICompanyrepository Companies { get; }
        ICentralRepository Centrals { get; }

         IEntityRepository<T> GetRepository<T>() where T : class, IEntity, new();

        Task<int> SaveAsync();
    }
}
