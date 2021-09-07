using CMS.Data.Abstract;
using CMS.Data.Concrete.EntityFramework.Contexts;
using CMS.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Services.Abstract;
using CMS.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using CMS.Entities.Concrete;
using CMS.Services.AutoMapper.Profiles;

namespace CMS.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<CMSDbContext>();
            serviceCollection.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<CMSDbContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICentralService, CentralManager>();
            serviceCollection.AddScoped<ICompanyService, CompanyManager>();
            serviceCollection.AddScoped<IMissionCommentService, MissionCommentManager>();
            serviceCollection.AddScoped<IDomainService, DomainManager>();
            serviceCollection.AddScoped<IMailService, MailManager>();
            serviceCollection.AddScoped<INoteService, NoteManager>();
            serviceCollection.AddScoped<IProjectService, ProjectManager>();
            serviceCollection.AddScoped<IStatusService, StatusManager>();
            serviceCollection.AddScoped<ITagService, TagManager>();
            serviceCollection.AddScoped<IMissionService, MissionManager>();

            serviceCollection.AddAutoMapper(
                typeof(CentralProfile),
                typeof(CompanyProfile),
                typeof(DomainProfile),
                typeof(MailProfile),
                typeof(MissionProfile)
                );

            return serviceCollection;
        }
    }
}
