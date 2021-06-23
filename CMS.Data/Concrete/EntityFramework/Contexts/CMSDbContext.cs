using CMS.Data.Concrete.EntityFramework.Mappings.Abstract;
using CMS.Data.Concrete.EntityFramework.Mappings.Concrete;
using CMS.Entities.Concrete;
using CMS.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Concrete.EntityFramework.Contexts
{
    public class CMSDbContext: DbContext
    {
        public DbSet<Central> Centrals { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionComment> MissionComments { get; set; }
        public DbSet<MissionCommentDocs> MissionCommentDocs { get; set; }
        public DbSet<MissionCommentReply> MissionCommentReplies { get; set; }
        public DbSet<MissionCommentReplyDocs> MissionCommentReplyDocs { get; set; }
        public DbSet<MissionTag> MissionTags { get; set; }
        public DbSet<MissionUser> MissionUsers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTag> ProjectTags { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=CMS;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;"
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply Configurations
            modelBuilder.ApplyConfiguration(new CentralMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new DomainMap());
            modelBuilder.ApplyConfiguration(new MailMap());
            modelBuilder.ApplyConfiguration(new MissionCommentDocsMap());
            modelBuilder.ApplyConfiguration(new MissionCommentMap());
            modelBuilder.ApplyConfiguration(new MissionCommentReplyDocsMap());
            modelBuilder.ApplyConfiguration(new MissionCommentReplyMap());
            modelBuilder.ApplyConfiguration(new MissionMap());
            modelBuilder.ApplyConfiguration(new MissionTagMap());
            modelBuilder.ApplyConfiguration(new MissionUserMap());
            modelBuilder.ApplyConfiguration(new NoteMap());
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new ProjectTagMap());
            modelBuilder.ApplyConfiguration(new ProjectUserMap());
            modelBuilder.ApplyConfiguration(new ReminderMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
            modelBuilder.ApplyConfiguration(new TagMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            // DB Relations

            modelBuilder.Entity<Central>()
                .HasOne(c => c.Parent)
                .WithMany(p => p.Centrals)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(c => c.ParentId);

            modelBuilder.Entity<Domain>()
                .HasOne(n => n.Parent)
                .WithMany(p => p.Domains)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(n => n.ParentId);

            modelBuilder.Entity<Mail>()
                .HasOne(m => m.Parent)
                .WithMany(p => p.Mails)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(m => m.ParentId);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Parent)
                .WithMany(p => p.Notes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(n => n.ParentId);

            modelBuilder.Entity<Reminder>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reminders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Reminder>()
                .HasOne(n => n.Parent)
                .WithMany(p => p.Reminders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(n => n.ParentId);

            modelBuilder.Entity<Mission>()
                .HasOne(m => m.Status)
                .WithMany(s => s.Missions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(m => m.StatusId);

            modelBuilder.Entity<MissionComment>()
                .HasOne(e => e.User)
                .WithMany(u => u.MissionComments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(e => e.UserId);
            
            modelBuilder.Entity<MissionComment>()
                .HasOne(e => e.Parent)
                .WithMany(p => p.MissionComments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<MissionCommentReply>()
                .HasOne(e => e.User)
                .WithMany(u => u.MissionCommentReplies)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<MissionCommentReply>()
                .HasOne(e => e.Parent)
                .WithMany(p => p.Replies)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Status)
                .WithMany(s => s.Projects)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.StatusId);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CompanyId);
        }
    }
}
