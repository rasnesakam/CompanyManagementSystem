using CMS.Data.Abstract;
using CMS.Data.Concrete.EntityFramework.Contexts;
using CMS.Data.Concrete.EntityFramework.Repositories;
using CMS.Shared.Data.Abstract;
using CMS.Shared.Data.Concrete.EntityFramework;
using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Concrete
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly CMSDbContext _context;

        private EFEntityBaseRepository _eFEntityBaseRepository;
        private EFCentralRepository _eFCentralRepository;
        private EFCompanyRepository _eFCompanyRepository;
        private EFDomainRepository _eFDomainRepository;
        private EFMailRepository _eFMailRepository;
        private EFMissionCommentRepository _eFMissionCommentRepository;
        private EFMissionCommentDocsRepository _eFMissionCommentDocsRepository;
        private EFMissionCommentReplyRepository _eFMissionCommentReplyRepository;
        private EFMissionCommentReplyDocsRepository _eFMissionCommentReplyDocsRepository;
        private EFMissionRepository _eFMissionRepository;
        private EFMissionTagRepository _eFMissionTagRepository;
        private EFMissionUserRepository _eFMissionUserRepository;
        private EFNoteRepository _eFNoteRepository;
        private EFProjectRepository _eFProjectRepository;
        private EFProjectTagRepository _eFProjectTagRepository;
        private EFProjectUserRepository _eFProjectUserRepository;
        private EFReminderRepository _eFReminderRepository;
        private EFStatusRepository _eFStatusRepository;
        private EFTagRepository _eFTagRepository;

        public UnitOfWork(CMSDbContext context)
        {
            _context = context;
        }

        public IEntityBaseRepository BaseRepository => _eFEntityBaseRepository ?? new EFEntityBaseRepository(_context);
        public ITagRepository Tags => _eFTagRepository ?? new EFTagRepository(_context);

        public IStatusRepository Statuses => _eFStatusRepository ?? new EFStatusRepository(_context);

        public IReminderRepository Reminders => _eFReminderRepository ?? new EFReminderRepository(_context);

        public IProjectUserRepository ProjectUsers => _eFProjectUserRepository ?? new EFProjectUserRepository(_context);

        public IProjectTagRepository ProjectTags => _eFProjectTagRepository ?? new EFProjectTagRepository(_context);

        public IProjectRepository Projects => _eFProjectRepository ?? new EFProjectRepository(_context);

        public INoteRepository Notes => _eFNoteRepository ?? new EFNoteRepository(_context);

        public IMissionUserRepository MissionUsers => _eFMissionUserRepository ?? new EFMissionUserRepository(_context);

        public IMissionTagRepository MissionTags => _eFMissionTagRepository ?? new EFMissionTagRepository(_context);

        public IMissionRepository Missions => _eFMissionRepository ?? new EFMissionRepository(_context);

        public IMissionCommentRepository MissionComments => _eFMissionCommentRepository ?? new EFMissionCommentRepository(_context);

        public IMissionCommentDocRepository MissionCommentDocs => _eFMissionCommentDocsRepository ?? new EFMissionCommentDocsRepository(_context);

        public IMCommentReplyRepository MissionCommentReplies => _eFMissionCommentReplyRepository ?? new EFMissionCommentReplyRepository(_context);

        public IMCReplyDocRepository MissionCommentReplyDocs => _eFMissionCommentReplyDocsRepository ?? new EFMissionCommentReplyDocsRepository(_context);

        public IMailRepository Mails => _eFMailRepository ?? new EFMailRepository(_context);

        public IDomainRepository Domains => _eFDomainRepository ?? new EFDomainRepository(_context);

        public ICompanyrepository Companies => _eFCompanyRepository ?? new EFCompanyRepository(_context);

        public ICentralRepository Centrals => _eFCentralRepository ?? new EFCentralRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        IEntityRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new EFEntityRepositoryBase<T>(_context);
        }
    }
}
