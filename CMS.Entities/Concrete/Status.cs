﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Entities.Abstract;

namespace CMS.Entities.Concrete
{
    public class Status: ColoredEntity
    {
        public ICollection<Project> Projects { get; set; }
        public ICollection<Mission> Missions { get; set; }
    }
}
