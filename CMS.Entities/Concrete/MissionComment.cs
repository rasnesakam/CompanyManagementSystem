using CMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CMS.Entities.Concrete
{
    public class MissionComment : CommentEntityBase<Mission>
    {
        public ICollection<MissionCommentDocs> Docs { get; set; }
        public ICollection<MissionCommentReply> Replies { get; set; }
    }
}
