using MVC6_QAndA.CC.Interfaces;
using MVC6_QAndA.CC.TransferObject;
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
            throw new NotImplementedException();
        }

        public QuestionTO Update(QuestionTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
