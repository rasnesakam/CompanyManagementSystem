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
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            CreateMap<DomainAddDto, Domain>().ForMember(dest => dest.CreateDate, opt => opt.MapFrom(x => DateTime.Now));
            //CreateMap<DomainUpdateDto, Domain>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
