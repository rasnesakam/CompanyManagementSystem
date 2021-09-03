using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Shared.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace CMS.Entities.Concrete
{
    public class User:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Avatar { get; set; }

        public ICollection<CompanyUsers> CompanyUsers { get; set; }

        public ICollection<Reminder> Reminders { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }
        public ICollection<MissionUser> MissionUsers { get; set; }
        public ICollection<MissionComment> MissionComments { get; set; }
        public ICollection<MissionCommentReply> MissionCommentReplies { get; set; }
    }
}
