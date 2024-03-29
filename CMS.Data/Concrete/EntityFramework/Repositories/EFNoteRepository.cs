﻿using CMS.Data.Abstract;
using CMS.Entities.Concrete;
using CMS.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Concrete.EntityFramework.Repositories
{
    public class EFNoteRepository: EFEntityRepositoryBase<Note>, INoteRepository
    {
        
        public EFNoteRepository(DbContext context): base(context)
        {
        }
    }
}
