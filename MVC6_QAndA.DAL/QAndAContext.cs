using Microsoft.EntityFrameworkCore;
using MVC6_QAndA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.DAL
{
    public class QAndAContext : DbContext
    {
        public QAndAContext()
        {
        }

        public QAndAContext(DbContextOptions<QAndAContext> options) : base(options)
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
