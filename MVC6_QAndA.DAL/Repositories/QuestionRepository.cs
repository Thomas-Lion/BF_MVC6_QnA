using MVC6_QAndA.CC.Interfaces;
using MVC6_QAndA.CC.TransferObject;
using MVC6_QAndA.DAL.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QAndAContext context;

        public QuestionRepository(QAndAContext context)
        {
            this.context = context;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public bool Archive(QuestionTO entity)
        {
            throw new NotImplementedException();
        }

        public QuestionTO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<QuestionTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public QuestionTO Insert(QuestionTO entity)
        {
            if (entity is null)
            {
                 throw new ArgumentNullException();
            }
            if (entity.Id != 0)
            {
                return entity;
            }
            var result = context.Questions.Add(entity.ToEF());
            return result.Entity.ToTO();
        }

        public QuestionTO Update(QuestionTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
