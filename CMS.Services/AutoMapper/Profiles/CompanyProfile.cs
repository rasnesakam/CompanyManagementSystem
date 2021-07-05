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
    public class CompanyProfile: Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyAddDto, Company>().ForMember(dest => dest.CreateDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<CompanyUpdateDto, Company>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }

}
