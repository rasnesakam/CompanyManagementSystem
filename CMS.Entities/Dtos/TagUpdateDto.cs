﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class TagUpdateDto: TagAddDto
    {
        [Required]
        public int Id { get; set; }
    }
}