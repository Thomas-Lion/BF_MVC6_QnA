using MVC6_QAndA.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace MVC6_QAndA.DAL
{
    public class QAndAContext : IdentityDbContext<UserEF ,IdentityRole, string>
    {
        public QAndAContext() {}

        //public QAndAContext(DbContextOptions<QAndAContext> options) : base(options)
        //{
        //}

        public QAndAContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source=QAndADb.db;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<AnswerEF> Answers { get; set; }
        public DbSet<QuestionEF> Questions { get; set; }
    }
}
