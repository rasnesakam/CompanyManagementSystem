using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Entities.Abstract;

namespace CMS.Entities.Concrete
{
    public class Company: PrimitiveEntity
    {
        public string BillAddress{ get; set; }
        public long TaxNum { get; set; }
        public string EMail { get; set; }
        public long ContactNumber { get; set; }
        public string Icon { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Reminder> Reminders { get; set; }
        public ICollection<Mail> Mails { get; set; }
        public ICollection<Central> Centrals { get; set; }
        public ICollection<Domain> Domains { get; set; }
        public ICollection<CompanyUsers> CompanyUsers { get; set; }

    }
}
