

using AutoMapper;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;

namespace CMS.Api.AutoMapper.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
        }
    }
}
