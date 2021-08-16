using AutoMapper;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.AutoMapper.Profiles
{
    public class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectAddDto, Project>().ForMember(dest => dest.CreateDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ProjectUpdateDto, Project>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
