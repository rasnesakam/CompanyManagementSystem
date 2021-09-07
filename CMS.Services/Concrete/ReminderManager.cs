using AutoMapper;
using CMS.Data.Abstract;
using CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Concrete
{
    public class ReminderManager : EntityManagerBase<Reminder>
    {
        public ReminderManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
