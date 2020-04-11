using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleExam.Models;

namespace SimpleExam.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Question>()
                .HasMany(x => x.Answers)
                .WithOne(x => x.Question)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExamAssignment>()
                .HasIndex(x => new { x.ExamId, x.GroupId })
                .IsUnique();

            builder.Entity<StudentGroup>()
                .HasKey(x => new { x.AppUserId, x.GroupId });
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ExamAssignment> ExamAssignments { get; set; }
        public DbSet<ExamAssignmentSetting> ExamAssignmentSettings { get; set; }
    }
}
