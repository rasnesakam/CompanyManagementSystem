using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Entities.Abstract;

namespace CMS.Entities.Concrete
{
    public class MissionCommentReply:CommentEntityBase<MissionComment>
    {
        public ICollection<MissionCommentReplyDocs> Docs { get; set; }
    }
}
