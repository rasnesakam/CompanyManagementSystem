﻿using CMS.Entities.Abstract;
using CMS.Entities.Concrete;
using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class CommentDto<CEntity,PEntity>: DtoGetBase
        where PEntity: EntityBase,new()
        where CEntity: CommentEntityBase<PEntity>
    {
        public CEntity Comment { get; set; }
    }
}
