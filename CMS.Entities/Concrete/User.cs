using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Shared.Entities.Abstract;
namespace CMS.Entities.Concrete
{
    public class User: EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Reminder> Reminders { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }
        public ICollection<MissionUser> MissionUsers { get; set; }
        public ICollection<MissionComment> MissionComments { get; set; }
        public ICollection<MissionCommentReply> MissionCommentReplies { get; set; }
    }
}
