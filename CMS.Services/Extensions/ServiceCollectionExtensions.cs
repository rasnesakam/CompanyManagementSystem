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

namespace CMS.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<CMSDbContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICentralService, CentralManager>();
            serviceCollection.AddScoped<ICompanyService, CompanyManager>();
            serviceCollection.AddScoped<IDomainService, DomainManager>();
            serviceCollection.AddScoped<IMailService, MailManager>();
            return serviceCollection;
        }
    }
}
